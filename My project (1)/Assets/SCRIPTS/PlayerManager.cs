using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    [Header("Game Object")]
    //Player GameObject
    public GameObject player;
    public Rigidbody rigidBody;
    //Player Scripts
    [Header("Player Scripts")]
    public InputManager InputManager;
    PlayerLocomotion playerLocomotion;
    //Player Stats
    [Header("Player Stats")]

    [Range(0f,1f)]

    public float movementSpeed;
    [Range(0f,1f)]
    public float rotationSpeed;
    [Header("Player Scripts")]
    public PlayerAnimation playerAnimation;
    public Animator playerAnim;


    // Start is called before the first frame update
    private void Awake()
    {
        //if two or more intance, delete self, else use self
        if (Instance != null && Instance != this) { Destroy(this); }
        else { Instance = this; }
        InputManager = player.GetComponent<InputManager>();
        playerLocomotion = player.GetComponent <PlayerLocomotion>();
        rigidBody = player.GetComponent<Rigidbody>();
        playerAnim = player.GetComponentInChildren<Animator>();
        playerAnimation = player.GetComponent<PlayerAnimation>();
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
