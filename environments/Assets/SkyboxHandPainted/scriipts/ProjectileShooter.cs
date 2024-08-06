using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int maxProjectiles = 10;
    public float projectileSpeed = 20f;
    public Transform shootPoint;

    private List<GameObject> projectiles = new List<GameObject>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        if (projectiles.Count < maxProjectiles)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            projectiles.Add(projectile);
        }
        else
        {
            Debug.Log("Maximum number of projectiles reached!");
        }
    }

    private void DestroyProjectiles()
    {
        foreach (GameObject projectile in projectiles)
        {
            Destroy(projectile);
        }
        projectiles.Clear();
    }

    private void OnDestroy()
    {
        DestroyProjectiles();
    }
}