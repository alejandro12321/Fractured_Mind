using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemDoor : MonoBehaviour
{
    public bool Dooropen = false;
    public float Dooropenangle = 0.0f;
    public float Closeopenangle = 95f;
    public float smooth = 3.0f;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Dooropen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, Dooropenangle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else 
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, Closeopenangle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }
    }

    public void ChangeDoorState()
    {
        Dooropen = !Dooropen;
    }
}
