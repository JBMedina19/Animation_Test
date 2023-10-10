using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Vector3 moveDirection;
    Transform cameraObject;
    private void Awake()
    {

        cameraObject = Camera.main.transform;
    }

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();

    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput ;
        moveDirection.Normalize();
        moveDirection.y = 0;

        //Line that moves the player
        moveDirection = moveDirection * PlayerManager.Instance.movementSpeed;


        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.playerRigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        //new script
        if (targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation,targetRotation, PlayerManager.Instance.rotationSpeed);

        transform.rotation = playerRotation;
    }

   

}
