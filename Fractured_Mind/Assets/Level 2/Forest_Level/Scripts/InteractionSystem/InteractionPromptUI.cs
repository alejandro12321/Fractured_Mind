using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] public GameObject uiPanel;
    public bool isDisplayed = false;

    private void Start()
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
        StartCoroutine(enfocarCamara());
    }
    IEnumerator enfocarCamara()
    {
        while (true)
        {
            var rotation = mainCam.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
            yield return null;
        }
    }
    public void setUpPrompt(string prompt)
    {
        promptText.text = prompt;
        uiPanel.SetActive(true);
        isDisplayed = true;
    }
    public void closePrompt()
    {
        isDisplayed = false;
        uiPanel.SetActive(false);
    }
}
