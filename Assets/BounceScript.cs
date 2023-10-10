using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public int maxBounces = 4;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBulletAtNearestEnemy();
        }
    }

    private void ShootBulletAtNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            Vector3 direction = nearestEnemy.transform.position - firePoint.position;
            bulletRigidbody.velocity = direction.normalized * bulletSpeed;

            // Attach a bullet behavior script (e.g., BulletBehavior) to the bullet for bouncing
            BulletScript bulletBehavior = bullet.AddComponent<BulletScript>();
            bulletBehavior.Initialize(maxBounces, nearestEnemy);
        }
    }
}







