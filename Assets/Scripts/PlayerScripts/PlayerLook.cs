using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera Camera;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    private float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        if (pauseMenu.gameisPaused==false)
        {
            float mouseX = input.x;
            float mouseY = input.y;

            // Calculates camera rotation
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, -80f, 80f);

            Camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            // roatate player to look left/right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
    }
}
