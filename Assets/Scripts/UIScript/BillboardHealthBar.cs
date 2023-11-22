using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardHealthBar : MonoBehaviour
{

    public Transform cam;

    /// <summary>
    /// Late update so this happens after the camera itself updates
    /// </summary>
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
