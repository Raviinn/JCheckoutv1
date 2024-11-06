using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    private float xRotation;
    public bool isInPosition;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = 300f;
        xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        isInPosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInPosition)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            player.Rotate(Vector3.up * mouseX);
        }
        if (isInPosition)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
