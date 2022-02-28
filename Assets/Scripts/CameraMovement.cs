using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private float mouseSens = 100f;
    public float xRotaion = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotaion -= mouseY;
        xRotaion = Mathf.Clamp(xRotaion, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotaion, 0f, 0f);
        Player.Rotate(Vector3.up * mouseX);
    }
}
