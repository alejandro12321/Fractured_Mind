using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position; //Se asigna la posicion de la camara obteniendo la posicion actual - la posicion del jugador
    }
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(playerTransform.position.x + cameraOffset.x, transform.position.y, playerTransform.position.z + cameraOffset.z); //Seguimiento del jugador
        transform.position = newPos; //Transforma la camara a la nueva posicion
    }
}
