using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAttackTrigger : MonoBehaviour
{

    public Animator wolfAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("Hola");



        }
    }
    
}
