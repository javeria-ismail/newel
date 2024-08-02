using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float stopDistance = 1.0f; // distance from the point to stop running
    public Transform[] stopPoints; // array of points on the plane where the character should stop running
    private Animator animator; // reference to the Animator component
    private bool isRunning = true; // flag to track if the character is running

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the character is close to any of the stop points
        foreach (Transform stopPoint in stopPoints)
        {
            float distance = Vector3.Distance(transform.position, stopPoint.position);
            if (distance < stopDistance)
            {
                // Stop running and transition to standing still animation
                isRunning = false;
                animator.SetBool("isRunning", false);
                break;
            }
        }

        // If the character is not close to any stop point, continue running
        if (isRunning)
        {
            animator.SetBool("isRunning", true);
        }
    }
}