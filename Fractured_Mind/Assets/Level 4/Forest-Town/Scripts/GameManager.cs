using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public float time;
    public bool isScoreChanged;
    public bool isTimeRunning;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI timeDisplay;
    public static GameManager instance;
    private GameObject player;
    public bool shouldResetGame = false;
    
    private void Awake()
{
    // Verificar si ya hay una instancia del GameManager
    if (instance == null)
    {
        // Si no hay una instancia, asignar esta instancia a la propiedad 'instance'
        instance = this;
    }
    else
    {
        // Si ya hay una instancia, destruir este objeto para evitar duplicados
        Destroy(gameObject);
    }

    // Mantener este objeto presente en todas las escenas
    DontDestroyOnLoad(gameObject);
}

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isScoreChanged = false;
        time = 250.0f; // Tiempo inicial en segundos
        isTimeRunning = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScoreChanged)
        {
            Debug.Log("¡El score ha sido cambiado!");
            scoreDisplay.text="Steaks: "+score.ToString();

            isScoreChanged = false;
        }
        if (isTimeRunning)
        {
            time -= Time.deltaTime; // Resta el tiempo transcurrido desde el último frame
            UpdateTimeDisplay();
            
            if (time <= 0)
            {
                isTimeRunning = false;
                player = GameObject.FindGameObjectWithTag("Player");
                Animator animator = player.GetComponent<Animator>();
                animator.SetBool("isDie", true);
                StartCoroutine(ResetGame());
                timeDisplay.text = "END";

                
                
                
            }
        }
        if (shouldResetGame)
        {
            ResetValues(); // Restablece los valores del marcador y el tiempo
            shouldResetGame = false; // Reinicia la variable para evitar que se reinicie constantemente
        }
   
    }

    void UpdateTimeDisplay()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeDisplay.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
    public void AddScore(int amount)
    {
        score += amount;
        isScoreChanged = true;
    }
    public void ResetValues()
    {
        score = 0;
        isScoreChanged = false;
        time = 250.0f;
        isTimeRunning = true;

        // Buscar el objeto "Canvas"
        GameObject canvasObject = GameObject.Find("Canvas");

        // Obtener las referencias a los componentes TextMeshProUGUI
        timeDisplay = canvasObject.transform.Find("time_display").GetComponent<TextMeshProUGUI>();
        scoreDisplay = canvasObject.transform.Find("score_display").GetComponent<TextMeshProUGUI>();
    }

    
    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);

        // Reinicia el juego
        GameManager.instance.shouldResetGame = true;

        // Carga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}