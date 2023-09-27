using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public GameObject player;
    public InputManager InputManager;
    PlayerLocomotion playerLocomotion;
    public Rigidbody rigidBody;
    [Range(0,50)]
    public float movementSpeed;
    [Range(0,50)]
    public float rotationSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
        InputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent <PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.HandleAllInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }
}
