using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCInteractable : MonoBehaviour
{

    public GameObject _DialogueBox;
    public TextMeshPro text;
    private CharacterController _controller;
    private GameObject player;

    [SerializeField]
    private List<string> _Messages;

    private void Start() {
         //Llama al componente de movimiento para poder mover el personaje
        player=GameObject.FindWithTag("Player"); 
        _controller = player.GetComponent<CharacterController>(); //Se instancia el Controlador que se tiene asignado al objeto Player

    }
    public void Interact(){

        Debug.Log("Interactua");
        

       teleport(new Vector3(1,1,10));

    }
    public void teleport(Vector3 position){

       
        Vector3 posicionAct=_controller.transform.position;
        _controller.transform.Translate(10,10,10);
     
        
    }
}
