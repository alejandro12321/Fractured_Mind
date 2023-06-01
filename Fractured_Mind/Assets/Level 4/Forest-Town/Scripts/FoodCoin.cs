using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCoin : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject); // Destruye la comida 
            gameManager.AddScore(1);
        }
    }
}
