using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class credits : MonoBehaviour
{
    public TextMeshProUGUI creditosText; // Referencia al componente TextMeshProUGUI para mostrar los créditos
    public float scrollSpeed = 1f; // Velocidad de desplazamiento de los créditos
    public float delayBeforeReset = 2f; // Tiempo de espera antes de reiniciar el juego

    private RectTransform creditosRectTransform; // Referencia al componente RectTransform de los créditos
    private float creditosHeight; // Altura total de los créditos
    private bool isScrolling = false; // Indica si los créditos están en movimiento

    private void Start()
    {
        creditosRectTransform = creditosText.GetComponent<RectTransform>();
        creditosHeight = creditosRectTransform.rect.height;
        MostrarCreditos();
    }

    private void Update()
    {
        if (isScrolling)
        {
            ScrollCredits();
        }
    }

    public void MostrarCreditos()
    {
        creditosRectTransform.anchoredPosition = Vector2.zero; // Reiniciar la posición de los créditos al inicio
        isScrolling = true;
    }

    private void ScrollCredits()
    {
        Vector2 position = creditosRectTransform.anchoredPosition;
        position.y += scrollSpeed * Time.deltaTime;

        if (position.y >= creditosHeight)
        {
            isScrolling = false;
            StartCoroutine(ResetGame());
        }
        else
        {
            creditosRectTransform.anchoredPosition = position;
        }
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(delayBeforeReset);

        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}