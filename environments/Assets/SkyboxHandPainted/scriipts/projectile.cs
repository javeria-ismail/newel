
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public LineRenderer trajectoryLine; // Assign the Line Renderer component in the Inspector
    public Transform bowEndPosition; // Assign the bow's end position in the Inspector
    public float initialVelocity = 15f; // Initial velocity of the projectile
    public float gravity = 9.81f; // Gravity value
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public int maxProjectiles = 20; // Maximum number of projectiles allowed

    private List<Vector3> trajectoryPoints; // List to store the trajectory points
    private Vector3 initialMousePosition; // Store the initial mouse position
    private int projectileCount = 0; // Counter for the number of projectiles shot

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            float deltaY = mousePosition.y - initialMousePosition.y;

            // Calculate the direction of the projectile based on the mouse drag
            Vector3 direction = bowEndPosition.right * -1 + Vector3.up * deltaY * 0.01f;

            // Calculate the trajectory points with a very short length
            trajectoryPoints = CalculateTrajectory(bowEndPosition.position, direction, initialVelocity, 6.8f);

            // Update the Line Renderer with the trajectory points
            trajectoryLine.positionCount = trajectoryPoints.Count;
            trajectoryLine.SetPositions(trajectoryPoints.ToArray());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Shoot the projectile when the mouse button is released
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Check if the maximum number of projectiles has been reached
        if (projectileCount < maxProjectiles)
        {
            // Instantiate the projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, bowEndPosition.position, Quaternion.identity);

            // Add a Rigidbody and Collider to the projectile
            Rigidbody rb = projectile.AddComponent<Rigidbody>();
            Collider collider = projectile.AddComponent<SphereCollider>();

            // Set the projectile's velocity
            rb.velocity = CalculateInitialVelocity(trajectoryPoints);

            // Increment the projectile count
            projectileCount++;
        }
        else
        {
            Debug.Log("Maximum number of projectiles reached!");
        }
    }

    Vector3 CalculateInitialVelocity(List<Vector3> trajectoryPoints)
    {
        // Calculate the initial velocity based on the trajectory points
        Vector3 direction = trajectoryPoints[1] - trajectoryPoints[0];
        return direction.normalized * initialVelocity;
    }

    // ////////// for not straight line //////////
    List<Vector3> CalculateTrajectory(Vector3 startPosition, Vector3 direction, float initialVelocity, float maxLength)
    {
        List<Vector3> trajectoryPoints = new List<Vector3>();

        float time = 0f;
        float deltaTime = 0.005f;

        while (time < maxLength) // Limit the trajectory length to maxLength
        {
            Vector3 position = startPosition + direction * initialVelocity * time + 0.5f * gravity * time * time * Vector3.down;
            trajectoryPoints.Add(position);

            time += deltaTime;
        }

        return trajectoryPoints;
    }
    ///////////// for straight line projection ///////////
    // List<Vector3> CalculateTrajectory(Vector3 startPosition, Vector3 direction, float initialVelocity, float maxLength)
    // {
    //     List<Vector3> trajectoryPoints = new List<Vector3>();

    //     float time = 0f;
    //     float deltaTime = 0.01f;

    //     Vector3 currentPosition = startPosition;

    //     // Increase the maxLength to generate a longer trajectory
    //     float extendedMaxLength = maxLength * 40f; // or any other multiplier

    //     while (Vector3.Distance(currentPosition, startPosition) < extendedMaxLength)
    //     {
    //         trajectoryPoints.Add(currentPosition);

    //         // Move in a straight line
    //         currentPosition += direction * deltaTime * initialVelocity;

    //         time += deltaTime;
    //     }

    //     return trajectoryPoints;
    // }
}

// Add this script to the projectile prefab
public class ProjectileCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Handle the collision with other objects
        Debug.Log("Collision detected!");
        // You can also destroy the projectile or perform other actions here
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Projectile : MonoBehaviour
// {
//     public float speed = 20f;
//     public float lifetime = 2f;

//     private Rigidbody rb;

//     private void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.velocity = transform.forward * speed;
//         Destroy(gameObject, lifetime);
//     }

//     private void OnCollisionEnter(Collision collision)
//     {
//         Destroy(gameObject);
//     }
// }