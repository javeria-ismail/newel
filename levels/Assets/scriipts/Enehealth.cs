using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Enehealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health (shots it can take)
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Debug.Log($"{currentHealth - 1} health");
        if (currentHealth <= 0)
        {
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
        Debug.Log($"{currentHealth - 1} health me");
        if (collision.gameObject.CompareTag("playerBullet"))
        {
            TakeDamage(1); // Reduce health by 1 for each bullet hit
            Debug.Log("Attacking the enemy.");
            Destroy(collision.gameObject); // Destroy the bullet after it hits the cylinder
        }
    }
}