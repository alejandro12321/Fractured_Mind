using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectMessage : MonoBehaviour
{
    public string message;
    public string name;
    public string Part1;
    public string Part2;
    public string Part3;

    public bool activeMessage;

    public GameObject messageUI;
    public TextMeshProUGUI parrafo;
    public TextMeshProUGUI segmento1;
    public TextMeshProUGUI segmento2;
    public TextMeshProUGUI segmento3;
    public TextMeshProUGUI puzzleName;

    // Start is called before the first frame update
    void Start()
    {
        messageUI.SetActive(false);
    }

    public void ActiveMessageState()
    {  
        puzzleName.text = name;
        segmento1.text = Part1;
        segmento2.text = Part2;
        segmento3.text = Part3;
        parrafo.text = message;       
        messageUI.SetActive(true);
        activeMessage = true;
    }

    public void DisableMessageState()
    {
        messageUI.SetActive(false);
        activeMessage = false;
    }
}
