using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    // assignar vilken sense jag vill ha 

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    //ingen arrow 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        //mathf.clamp gör så att det blir begränsat inom området -90f och 90f i detta fallet 

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotation av spelare         

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}