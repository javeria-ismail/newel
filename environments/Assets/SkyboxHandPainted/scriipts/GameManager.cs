using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    private int enemiesDestroyed = 0; // Count of destroyed enemies
    public int totalEnemies = 2; // Total number of enemies to be destroyed to win

    void Awake()
    {
        // Ensure there's only one instance of GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        Debug.Log("Enemies destroyed: " + enemiesDestroyed);

        if (enemiesDestroyed >= totalEnemies)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("You win, all enemies destroyed!");
        // Implement any additional end game logic here, such as loading a win screen or stopping the game
    }
}