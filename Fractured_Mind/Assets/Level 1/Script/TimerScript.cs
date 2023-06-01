using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float tiempoTotal = 60.0f;
    private float tiempoActual = 0.0f;
    public TextMeshProUGUI textoTiempo;

    void Start()
    {
        tiempoActual = tiempoTotal;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (tiempoActual > 0)
        {
            tiempoActual -= Time.deltaTime;
            int minutos = Mathf.FloorToInt(tiempoActual / 60);
            int segundos = Mathf.FloorToInt(tiempoActual % 60);
            textoTiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");
            yield return null;
        }

       textoTiempo.text = "Perdiste manco";
    }
}
