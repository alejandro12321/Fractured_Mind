using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoDeCamara : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - playerTransform.position; //Se asigna la posicion de la camara obteniendo la posicion actual - la posicion del jugador
    }
    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x + cameraOffset.x, playerTransform.position.y + cameraOffset.y, playerTransform.position.z + cameraOffset.z);
    }
 }
