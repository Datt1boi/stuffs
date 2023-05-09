using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public string damageTag = "GUN";  // tag of the game object that can damage the enemy

    private void Start()
    {
        currentHealth = maxHealth;
        GetComponent<BoxCollider>().isTrigger = true;
    }

    private void OnCollision3D(BoxCollider collision)
    {
        if (collision.gameObject.tag == damageTag)
        {
            TakeDamage(1); // Deal 1 damage to the enemy
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle enemy death logic here
        Destroy(gameObject);
    }
}

