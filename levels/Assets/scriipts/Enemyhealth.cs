using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health (shots it can take)
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{currentHealth} working");
        if (currentHealth <= 0)
        {
            Debug.Log($"{currentHealth} working");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Debug.Log("You win");
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet with the tag "enemyBullet"
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit
            Debug.Log("Attacking the enemy.");
            Destroy(collision.gameObject); // Destroy the bullet after it hits the cylinder
        }
    }
}