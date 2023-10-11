using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private PlayerMovement playerControls;
    public Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;


    float moveAmount;

    public void HandleAllInput()
    {
        HandleMovementInput();
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
        }

        playerControls.Enable();
        
    }

    private void OnDisable()
    {
        
    }
}

