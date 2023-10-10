using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //player controls
    private PlayerControls playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;

    //new script
    public float moveAmount;
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            //When we hit WASD or joystick,we will gonna record the movement to the variable movementinput(being vector2(up,down,left,right))
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    // Start is called before the first frame update

    public void HandleAllInput()
    {
        HandleMovementInput();
    }
    // Update is called once per frame
    private void HandleMovementInput() 
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        //new Script
        //clamps between 0 to 1 and Abs for it to make it always a positive
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        PlayerManager.Instance.animatorManager.UpdateAnimatorValues(0, moveAmount);
    }


}
