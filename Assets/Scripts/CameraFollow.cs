using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's Transform.
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement.
    public Vector3 offset;             // Offset between the camera and the player.

    private void Start()
    {
        playerTransform = PlayerManager.Instance.player.transform;
    }
    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            // Calculate the desired position for the camera.
            Vector3 desiredPosition = playerTransform.position + offset;

            // Use SmoothDamp to interpolate between the current position and desired position.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            // Update the camera's position.
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.Log("Player Not Found");
        }
    }
}
