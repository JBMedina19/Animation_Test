using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public static PlayerManager Instance { get; private set; }
    [Header("Components")]
    //Player Game Object
    public GameObject player;
    public Rigidbody playerRigidBody;
    //new script
    public Animator animator;
    //PlayerScripts
    public InputManager inputManager;
    public PlayerLocomotion playerLocomotion;
    //new script
    public AnimatorManager animatorManager;

    [Header("MovementStats")]
    //Player Stats
    public float movementSpeed;
    public float rotationSpeed;

    //New Scripts_2

    public float walkingSpeed;
    public float SprintingSpeed;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this){Destroy(this);}
        else{Instance = this;}
        inputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent<PlayerLocomotion>();
        //new script
        animatorManager = player.GetComponent<AnimatorManager>();
        playerRigidBody = player.GetComponent<Rigidbody>();
        //new script
        animator = player.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
