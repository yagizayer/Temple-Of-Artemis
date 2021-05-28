using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(CinemachineFreeLook))]
public class cinemachineLook : MonoBehaviour
{
    public CinemachineFreeLook cmLook;
    public float mouseSensivity = 10f;

    void Start()
    {
        if (cmLook == null)
        {
            cmLook = GetComponent<CinemachineFreeLook>();
        }
    }

    void Update()
    {
        float mouseX = SimpleInput.GetAxis("JoystickLookHorizontal");
        float mouseY = SimpleInput.GetAxis("JoystickLookVertical");


        Vector2 delta = new Vector2(mouseX , mouseY);
        cmLook.m_XAxis.Value += delta.x * mouseSensivity * 50 * Time.deltaTime;
        cmLook.m_YAxis.Value += delta.y * mouseSensivity * Time.deltaTime;
    }
}
