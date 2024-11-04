using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MouseLook : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity;
    private float xRotation;
    public bool isInCashier;
    // Start is called before the first frame update
    void Start()
    {
        mouseSensitivity = 300f;
        xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        isInCashier = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInCashier)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            player.Rotate(Vector3.up * mouseX);
        }
        if (isInCashier)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
