using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;

public class CineCamera : MonoBehaviour
{
    private InputManager _inputManager;
    private CinemachineOrbitalFollow cameraControl;
    public float keyboardSensitivity = 50f;

    void Start()
    {
        cameraControl = GetComponent<CinemachineOrbitalFollow>();
        _inputManager = FindFirstObjectByType<InputManager>();
    }

    void Update()
    {
        //Controls Zoom
        if (cameraControl.Radius - Input.mouseScrollDelta.y > 0 && cameraControl.Radius - Input.mouseScrollDelta.y < 20)
            cameraControl.Radius -= Input.mouseScrollDelta.y;
        //Controls Y rotation
        if (_inputManager.getRightClickDown())
        {
            if ((cameraControl.VerticalAxis.Value + _inputManager.getMouseVertical() > -10) && (cameraControl.VerticalAxis.Value + _inputManager.getMouseVertical() < 88))
                cameraControl.VerticalAxis.Value += _inputManager.getMouseVertical();
        }
        else
        {
            if ((cameraControl.VerticalAxis.Value + _inputManager.getVerticalTurningAxis() * Time.deltaTime * keyboardSensitivity > -10) 
                && (cameraControl.VerticalAxis.Value + _inputManager.getVerticalTurningAxis() * Time.deltaTime * keyboardSensitivity < 88))
                cameraControl.VerticalAxis.Value += _inputManager.getVerticalTurningAxis() * Time.deltaTime * keyboardSensitivity;
        }
    }
}
