using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    //Player Game Object
    public GameObject player;
    //PlayerScripts
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    //Player Stats
    public float movementSpeed;
    public float rotationSpeed;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this){Destroy(this);}
        else{Instance = this;}
        inputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent<PlayerLocomotion>();
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
