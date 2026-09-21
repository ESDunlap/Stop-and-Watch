using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;
public class CineCamera : MonoBehaviour
{
    private CinemachineOrbitalFollow cameraControl;

    void Start()
    {
        cameraControl = GetComponent<CinemachineOrbitalFollow>();
    }

    void Update()
    {
        //Controls Zoom
        if (cameraControl.Radius + Input.mouseScrollDelta.y > 0)
            cameraControl.Radius += Input.mouseScrollDelta.y;
        //Controls Y rotation
        if (Input.GetMouseButton(1))
        {
            if ((cameraControl.VerticalAxis.Value + Input.GetAxis("Mouse Y") > -10) && (cameraControl.VerticalAxis.Value + Input.GetAxis("Mouse Y") < 88))
                cameraControl.VerticalAxis.Value += Input.GetAxis("Mouse Y");
        }
    }
}
