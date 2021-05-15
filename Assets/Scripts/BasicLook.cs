using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicLook : MonoBehaviour
{
    public Transform target;
    public float mouseSensivity = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    public bool invertY = true;
    private void Start()
    {
        if (target == null)
        {
            target = transform;
        }
    }
    void Update()
    {

        float mouseX = SimpleInput.GetAxis("JoystickLookHorizontal") * mouseSensivity * Time.deltaTime;
        float mouseY = SimpleInput.GetAxis("JoystickLookVertical") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY* (invertY ? -1 : 1);
        yRotation += mouseX ;

        xRotation = Mathf.Clamp(xRotation, -60, 60);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
