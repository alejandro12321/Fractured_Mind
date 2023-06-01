using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PrisionPuzzle : MonoBehaviour
{

    public TextMeshProUGUI textPorcentaje;
    private int porcentaje;

    private bool pluma;
    private bool hueso;
    private bool tenedor;

    public bool isPuzzleActive;

    void Start()
    {
        textPorcentaje.text = "0%";
        porcentaje = 1;
        pluma = false;
        hueso = false;
        tenedor = false;
        isPuzzleActive = true;
        //StartCoroutine(Timer());
    }

    

    void Update() {
        switch (porcentaje)
        {
            case 1:
                textPorcentaje.text = "0%";
                break;
            case 2:
                textPorcentaje.text = "33%";
                break;
            case 3:
                textPorcentaje.text = "66%";
                break;
            case 4:
                textPorcentaje.text = "100%";
                break;
        }
        if (porcentaje >= 4)
        {
            isPuzzleActive = false;
        }
    }

    public void resolvePuzzle(string nameObject)
    {
        if (nameObject == "Quill" && pluma == false)
        {
            pluma = true;
            porcentaje += 1;
        }
        if (nameObject == "Fork" && tenedor == false)
        {
            tenedor = true;
            porcentaje += 1;
        }
        else if (nameObject == "BoneM" && hueso == false)
        {
            hueso = true;
            porcentaje += 1;
        }
    }

}
