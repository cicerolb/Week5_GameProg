using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerMovement playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public bool sprintInput;
    public bool walkInput;


    float moveAmount;

    public void HandleAllInput()
    {
        HandleMovementInput();
        HandleSprinting();
        HandleWalking();
    }

    // Update is called once per frame
    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput)+ Mathf.Abs(verticalInput));
        PlayerManager.Instance.playerAnimation.UpdateAnimatorValues(0, moveAmount);
    }

    private void OnEnable() 
    {
        if (playerControls == null)
        {
            playerControls = new PlayerMovement();

            //When we hit WASD, we will record the movement to a variable
            playerControls.Newactionmap.Movement.performed += i => movementInput = i.ReadValue<Vector2>();

            playerControls.PlayerAction.Sprint.performed += i => sprintInput = true;
            playerControls.PlayerAction.Sprint.canceled += i => sprintInput = false;

            playerControls.PlayerAction.Walk.performed += i => walkInput = true;
            playerControls.PlayerAction.Walk.canceled += i => walkInput = false;
        }

        playerControls.Enable();
        
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void HandleSprinting()
    {
        if (sprintInput && moveAmount > 0.5f)
        {
            PlayerManager.Instance.isSprinting = true;
        }
        else
        {
            PlayerManager.Instance.isSprinting = false;
        }
    }

    private void HandleWalking()
    {
        if (walkInput && moveAmount > 0.1f)
        {
            print("A");
            PlayerManager.Instance.isWalking = true;
        }
        else
        {
            PlayerManager.Instance.isWalking = false;
        }
    }
}

