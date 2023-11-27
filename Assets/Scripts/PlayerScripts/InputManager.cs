using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerGuns playerGun;

    public bool disabled = false;
    AudioManager audioManager;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        playerGun = GetComponent<PlayerGuns>();
        audioManager=GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        onFoot.Shoot.performed += ctx => playerGun.shootBullet(); // when "shoot" action performed call this function
    }

    void FixedUpdate()
    {
        if (!disabled)
            motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());

    }
    private void LateUpdate()
    {
        if (!disabled)
            look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
