using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;

    private float mouseX;
    private float mouseSensitivity = 100.0f;

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
    }
}
