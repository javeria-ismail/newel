// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;


// public class RotateCharacter : MonoBehaviour
// {
//     public float rotationSpeed = 5f; // adjust this value to control the rotation speed

//     private Vector3 mousePosition; // store the initial mouse position

//     void Update()
//     {
//         // Check if the left mouse button is pressed
//         if (Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Mouse button down");
//             // Store the initial mouse position
//             mousePosition = Input.mousePosition;
//         }
//         else if (Input.GetMouseButton(0))
//         {
//             Debug.Log("Mouse button held down");
//             // Calculate the mouse delta (difference between current and initial mouse positions)
//             Vector3 mouseDelta = Input.mousePosition - mousePosition;

//             Debug.Log("Mouse delta: " + mouseDelta);

//             // Rotate the character based on the mouse delta
//             transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed * Time.deltaTime);

//             Debug.Log("Character rotation: " + transform.eulerAngles);

//             // Update the initial mouse position
//             mousePosition = Input.mousePosition;
//         }
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class rotate : MonoBehaviour
// {
//     public float rotationSpeed = 5f; // adjust this value to control the rotation speed

//     private Vector3 mousePosition; // store the initial mouse position

//     void Update()
//     {
//         // Check if the left mouse button is pressed
//         if (Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Mouse button down");
//             // Store the initial mouse position
//             mousePosition = Input.mousePosition;
//         }
//         else if (Input.GetMouseButton(0))
//         {
//             Debug.Log("Mouse button held down");
//             // Calculate the mouse delta (difference between current and initial mouse positions)
//             Vector3 mouseDelta = Input.mousePosition - mousePosition;

//             Debug.Log("Mouse delta: " + mouseDelta);

//             // Rotate the character based on the mouse delta
//             transform.Rotate(Vector3.up, mouseDelta.x * rotationSpeed * Time.deltaTime);

//             // Check if the rotation exceeds the specified ranges
//             if (transform.eulerAngles.x > 2.663f)
//             {
//                 transform.eulerAngles = new Vector3(2.663f, transform.eulerAngles.y, transform.eulerAngles.z);
//             }
//             else if (transform.eulerAngles.x < -0.022f)
//             {
//                 transform.eulerAngles = new Vector3(-0.022f, transform.eulerAngles.y, transform.eulerAngles.z);
//             }


//             if (transform.eulerAngles.y > 51.5f)
//             {
//                 transform.eulerAngles = new Vector3(transform.eulerAngles.x, 51.5f, transform.eulerAngles.z);
//             }
//             else if (transform.eulerAngles.y < -56.1f)
//             {
//                 transform.eulerAngles = new Vector3(transform.eulerAngles.x, -56.1f, transform.eulerAngles.z);
//             }

//             if (transform.eulerAngles.z > 20.2f)
//             {
//                 transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 20.2f);
//             }
//             else if (transform.eulerAngles.z < -27.4f)
//             {
//                 transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -27.4f);
//             }

//             Debug.Log("Character rotation: " + transform.eulerAngles);

//             // Update the initial mouse position
//             mousePosition = Input.mousePosition;
//         }
//     }
// }







///////////////////      real one /////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationSpeed = 5f; // adjust this value to control the rotation speed

    private Vector3 mousePosition; // store the initial mouse position

    //private Vector3 mousePosition; // store the initial mouse position

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

            // Check if the rotation exceeds the specified ranges
            if (transform.eulerAngles.x > 2.663f)
            {
                transform.eulerAngles = new Vector3(2.663f, transform.eulerAngles.y, transform.eulerAngles.z);
            }
            else if (transform.eulerAngles.x < -0.022f)
            {
                transform.eulerAngles = new Vector3(-0.022f, transform.eulerAngles.y, transform.eulerAngles.z);
            }

            if (transform.eulerAngles.y > 160.06f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 160.06f, transform.eulerAngles.z);
            }
            else if (transform.eulerAngles.y < 66.383f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 66.383f, transform.eulerAngles.z);
            }

            if (transform.eulerAngles.z > 2.667f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 2.667f);
            }
            else if (transform.eulerAngles.z < -0.149f)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -0.149f);
            }

            Debug.Log("Character rotation: " + transform.eulerAngles);

            // Update the initial mouse position
            mousePosition = Input.mousePosition;
        }
    }
}









