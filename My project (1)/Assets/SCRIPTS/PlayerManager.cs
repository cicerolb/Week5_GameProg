using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public GameObject player;
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    public float movementSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
        inputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent <PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
