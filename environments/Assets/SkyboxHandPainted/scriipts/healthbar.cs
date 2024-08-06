using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    public void UpdatehealthbarEnemy(float maxHealth, float CurrentHealth)
    {
        slider.value = CurrentHealth / maxHealth;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + Vector3.up * 4; // Adjust the Y offset as needed
        }

        transform.rotation = cam.transform.rotation;


    }
}