using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int bounceCount = 0;
    private int maxBounces;
    private GameObject targetEnemy;

    public void Initialize(int maxBounces, GameObject enemy)
    {
        this.maxBounces = maxBounces;
        this.targetEnemy = enemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetEnemy && bounceCount < maxBounces)
        {
            // Calculate the reflection direction
            Vector3 incomingVector = collision.contacts[0].point - transform.position;
            Vector3 reflectDirection = Vector3.Reflect(incomingVector, collision.contacts[0].normal).normalized;

            // Set the new velocity based on the reflection direction
            GetComponent<Rigidbody>().velocity = reflectDirection * 4;

            // Increment the bounce count
            bounceCount++;
        }
    }
}
