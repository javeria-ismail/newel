//using System.Collections.Generic;
//using System.Collections;
//using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    public GameObject enemyPrefab; // Prefab for the enemy capsule
//    public Transform[] spawnPoints; // Points where enemies will be spawned
//    public Transform[] movePositions; // Positions where the enemies can move randomly
//  //  public Transform crystal; // Reference to the cylinder
//    public GameObject crystalPrefab; // Reference to the crystal prefab
//    public GameObject bulletPrefab; // Bullet prefab (sphere)

//    private List<GameObject> enemies = new List<GameObject>();

//    void Start()
//    {
//        SpawnEnemies();
//    }

//    void SpawnEnemies()
//    {
//        foreach (Transform spawnPoint in spawnPoints)
//        {
//            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
//            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
//            enemyAI.movePositions = movePositions;
//         //   enemyAI.crystalPrefab = crystal;
//            enemyAI.bulletPrefab = bulletPrefab;
//            GameObject crystal = Instantiate(crystalPrefab, spawnPoint.position + Vector3.forward * 2, Quaternion.identity); // Adjust the position as needed
//            enemyAI.crystal = crystal.transform; // Assign the instantiated crystal to the enemy AI

//            enemies.Add(enemy);
//        }
//    }
//}
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy character
    public Transform[] spawnPoints; // Points where enemies will be spawned
    public Transform[] movePositions; // Positions where the enemies can move randomly
    public GameObject crystalPrefab; // Reference to the crystal prefab
    public GameObject bulletPrefab; // Bullet prefab (sphere)

    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Instantiate the enemy at the spawn point
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();

            // Assign move positions and bullet prefab
            enemyAI.movePositions = movePositions;
            enemyAI.bulletPrefab = bulletPrefab;

            // Assign the crystal prefab to the enemy AI
            enemyAI.crystal = GameObject.FindWithTag("Crystal").transform;

            enemies.Add(enemy); // Add the enemy to the list
        }
    }
}