//using System.Collections;
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyAI : MonoBehaviour
//{
//    public Transform[] spawnPositions; // Positions where the enemy can spawn
//    public Transform[] movePositions; // Positions where the enemy can move randomly
//    public GameObject crystalPrefab; // Reference to the crystal prefab
//    public float attackRange = 5f; // Range within which the enemy will start attacking
//    public float attackInterval = 3f; // Time between each attack
//   // public int shotsToDestroy = 10; // Number of shots needed to destroy the cylinder
//    public GameObject bulletPrefab; // Bullet prefab (sphere)

//    private NavMeshAgent agent;
//    private bool isAttacking = false;
//    // private int shotsTaken = 0;
//    private Animator animator;
//    public Transform crystal; // Reference to the instantiated crystal

//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        animator = GetComponent<Animator>();
//        SpawnAtRandomPosition();
//        InstantiateCrystal();
//        MoveToRandomPosition();

//    }

//    void Update()
//    {
//        // Random movement
//        if (!agent.pathPending && agent.remainingDistance < 0.5f)
//        {
//            MoveToRandomPosition();
//        }

//        // Attack logic
//        if (crystal!=null&& Vector3.Distance(transform.position, crystal.position) < attackRange)
//        {
//            if (!isAttacking)
//            {
//                StartCoroutine(AttackCylinder());
//            }
//        }
//    }
//    void SpawnAtRandomPosition()
//    {
//        int randomIndex = Random.Range(0, spawnPositions.Length);
//        transform.position = spawnPositions[randomIndex].position;
//    }
//    void InstantiateCrystal()
//    {
//        // Instantiate the crystal prefab at a specified position
//        Vector3 crystalPosition = new Vector3(0, 0, 0); // Set this to the desired position
//        GameObject crystalInstance = Instantiate(crystalPrefab, crystalPosition, Quaternion.identity);
//        crystal = crystalInstance.transform;
//    }
//    void MoveToRandomPosition()
//    {
//        // Move to a random position in the array
//        int randomIndex = Random.Range(0, movePositions.Length);
//        agent.SetDestination(movePositions[randomIndex].position);
//    }


//    IEnumerator AttackCylinder()
//    {
//        isAttacking = true;
//        while (true)
//        {
//            Debug.Log("shooting...");
//           animator.SetTrigger("attack");

//            ShootBullet();
//            yield return new WaitForSeconds(attackInterval);
//        }
//    }


//    void ShootBullet()
//    {
//        // Instantiate a bullet and shoot towards the cylinder
//        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
//        Rigidbody rb = bullet.GetComponent<Rigidbody>();
//        bullet.tag = "enemyBullet";
//        rb.velocity = (crystal.position - transform.position).normalized * 10f; // Adjust speed as needed

//        // Destroy the bullet after 1 second
//        Destroy(bullet, 1f);
//    }
//}
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] movePositions; // Positions where the enemy can move randomly
    public Transform crystal; // Reference to the crystal
    public float attackRange = 5f; // Range within which the enemy will start attacking
    public float attackInterval = 3f; // Time between each attack
    public GameObject bulletPrefab; // Bullet prefab (sphere)

    private NavMeshAgent agent;
    private bool isAttacking = false;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        MoveToRandomPosition();
    }

    void Update()
    {
        // Random movement
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToRandomPosition();
        }

        // Attack logic
        if (crystal != null && Vector3.Distance(transform.position, crystal.position) < attackRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(AttackCrystal());
            }
        }
    }

    void MoveToRandomPosition()
    {
        // Move to a random position in the array
        int randomIndex = Random.Range(0, movePositions.Length);
        agent.SetDestination(movePositions[randomIndex].position);
    }

    IEnumerator AttackCrystal()
    {
        isAttacking = true;
        while (true)
        {
            Debug.Log("shooting...");
            animator.SetTrigger("attack");
            yield return new WaitForSeconds(attackInterval / 2); // Adjust if needed to sync with animation timing
            ShootBullet();
            yield return new WaitForSeconds(attackInterval / 2);
        }
    }

    void ShootBullet()
    {
        // Instantiate a bullet and shoot towards the crystal
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.tag = "enemyBullet";
        rb.velocity = (crystal.position - transform.position).normalized * 10f; // Adjust speed as needed

        // Destroy the bullet after 1 second
        Destroy(bullet, 1f);
    }
}