using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{   
    // Currently WASD is to move !!
    
    private CharacterController controller;
    AudioManager audioManager;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;   // gravity may or may not be needed
    private FootStepController footstepController;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepController = GetComponentInChildren<FootStepController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded == false && playerVelocity.y < 0)
        {
            playerVelocity.y = -9.8f;
        }
        controller.Move(playerVelocity * Time.deltaTime);

    }
}
