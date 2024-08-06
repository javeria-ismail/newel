using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private healthbar _healthbar;
    public int maxHealth = 10; // Maximum health (shots it can take)
    private int currentHealth;
    private int hitCount = 0; // Count the number of hits by player bullets
    public int requiredHits = 10; // Number of hits required to destroy the enemy

    private bool isHit = false; // Track if the enemy is hit to avoid double counting

    void Awake()
    {
        _healthbar = GetComponentInChildren<healthbar>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        _healthbar.UpdatehealthbarEnemy(maxHealth, currentHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hitCount++;
        _healthbar.UpdatehealthbarEnemy(maxHealth, currentHealth);

        if (hitCount >= requiredHits || currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.EnemyDestroyed(); // Notify GameManager of enemy destruction
        Destroy(gameObject);
        Debug.Log("Enemy destroyed");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerBullet") && !isHit)
        {
            isHit = true; // Set isHit to true to avoid double counting
            TakeDamage(1); // Reduce health by 1 for each bullet hit
            Debug.Log("Attacking the enemy... " + hitCount);
            Destroy(collision.gameObject); // Destroy the bullet after it hits the enemy

            StartCoroutine(ResetHit()); // Reset isHit after a short delay to allow new hits
        }
    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay as needed
        isHit = false; // Reset isHit to allow new hits to be registered
    }
}