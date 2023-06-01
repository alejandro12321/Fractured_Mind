using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Vida máxima del enemigo
    private float currentHealth; // Vida actual del enemigo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemigo recibió " + damageAmount + " de daño.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       
        Debug.Log("Enemigo muerto.");
        GameObject doorObject = GameObject.FindWithTag("door");
        Destroy(gameObject); // Destruir el objeto enemigo
        Destroy(doorObject); // Destruir el objeto enemigo
    }
}
