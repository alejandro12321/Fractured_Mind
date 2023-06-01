using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeEffect : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;
    private float delay=0.3f;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void EndCheck(string text){
        TextMeshProUGUI _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text="";
        StartCoroutine(TypeText(text));
    }
    public IEnumerator TypeText(string text){

            _textMeshPro.ForceMeshUpdate();
            foreach (char c in text)
            {
                _textMeshPro.text = _textMeshPro.text + c;
                yield return new WaitForSeconds(delay *Time.deltaTime);
                
            }
           
           
           }
        
    }

