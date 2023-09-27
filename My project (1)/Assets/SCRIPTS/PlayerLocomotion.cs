using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
 
    Vector3 moveDirection;
    Transform cameraObject;


    // Start is called before the first frame update
    private void Awake()
    {
       
        
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.InputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.InputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= PlayerManager.Instance.movementSpeed;
        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }

    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.InputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.InputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation = Quaternion.Slerp(transform.rotation, targetRotation, PlayerManager.Instance.rotationSpeed);
        transform.rotation = playerRotation;
    }
}
