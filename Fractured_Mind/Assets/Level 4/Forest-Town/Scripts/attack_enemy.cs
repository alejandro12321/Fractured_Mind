using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attack_enemy : MonoBehaviour
{
    public GameObject enemyObject; // Referencia al objeto enemigo
    public List<char> availableLetters; // Letras disponibles para presionar
    public int sequenceLength = 4; // Longitud de la secuencia de letras
    public TextMeshProUGUI sequenceText; // Referencia al componente TextMeshPro
    public float damageAmount = 10f; // Cantidad de daño al enemigo
    public GameObject dialogCanvas; 

    private List<char> currentSequence; // Secuencia actual generada
    private int currentLetterIndex; // Índice de la letra actual en la secuencia
    private bool isInteracting = false;
    private bool isScriptEnabled = true; // Estado actual del script

 private void Start()
    {
        
    }

    private void Update()
    {
        if (isInteracting && isScriptEnabled)
        {
            CheckInput();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isScriptEnabled)
        {
            GenerateSequence();
            isInteracting = true;
            dialogCanvas.GetComponent<Canvas>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isScriptEnabled)
        {
            isInteracting = false;
            dialogCanvas.GetComponent<Canvas>().enabled = false;
        }
    }

    private void GenerateSequence()
    {
        currentSequence = new List<char>();
        for (int i = 0; i < sequenceLength; i++)
        {
            int randomIndex = Random.Range(0, availableLetters.Count);
            currentSequence.Add(availableLetters[randomIndex]);
        }

        currentLetterIndex = 0;

        UpdateSequenceText();
    }

    private void CheckInput()
    {
        if (currentLetterIndex < currentSequence.Count)
        {
            char currentLetter = currentSequence[currentLetterIndex];
            if (Input.GetKeyDown(currentLetter.ToString()))
            {
                currentLetterIndex++;
                Debug.Log("Presionaste la tecla: " + currentLetter);

                if (currentLetterIndex == currentSequence.Count)
                {
                    DamageEnemy();
                }
            }
        }
        else if (Input.anyKeyDown)
        {
            Debug.Log("Te equivocaste en la secuencia. Reiniciando...");
            GenerateSequence();
        }
    }

    private void DamageEnemy()
    {
        if (enemyObject != null)
        {
            // Aplicar daño al enemigo con el tag "enemyh"
            EnemyHealth enemyHealth = enemyObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }

            // Deshabilitar el script attack_enemy
            isScriptEnabled = false;

            // Activar el efecto de rayo
            // Puedes implementar el código correspondiente aquí
            Debug.Log("Efecto de rayo lanzado al enemigo!");
            dialogCanvas.GetComponent<Canvas>().enabled = false;
        }

        GenerateSequence();
    }

    private void UpdateSequenceText()
    {
        string sequenceString = string.Join(" ", currentSequence);
        sequenceText.text = "Secuencia: " + sequenceString;
    }
}