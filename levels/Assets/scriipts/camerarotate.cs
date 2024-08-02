using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class camerarotate : MonoBehaviour
{
    public float rotationSpeed = 5f; // adjust this value to control the rotation speed

    private Vector3 mousePosition; // store the initial mouse position

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse button down");
            // Store the initial mouse position
            mousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse button held down");
            // Calculate the mouse delta (difference between current and initial mouse positions)
            Vector3 mouseDelta = Input.mousePosition - mousePosition;

            Debug.Log("Mouse delta: " + mouseDelta);

            // Rotate the character based on the mouse delta
            transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed * Time.deltaTime);

            Debug.Log("Character rotation: " + transform.eulerAngles);

            // Update the initial mouse position
            mousePosition = Input.mousePosition;
        }
    }
}






