using UnityEngine;
using System;
using UnityEngine.UIElements;
public class playerCamera : MonoBehaviour
{
    private HeroineController controller;
    private Transform target;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        controller = FindObjectOfType<HeroineController>();
    }

    void LateUpdate()
    {
        //Makes the camera move around vertically
        if (Input.GetMouseButton(1))
        {
            float rotateVertical = Input.GetAxis("Mouse Y");
            if ((Mathf.Sign(rotateVertical) == 1) && (this.transform.localPosition.y) < 5 ||
                ((Mathf.Sign(rotateVertical) == -1) && (this.transform.localPosition.y) > -1000))
                transform.position -= Vector3.down * rotateVertical * Time.deltaTime * 100f;
        }

        //Makes sure the camera does not go into the ground or ceiling
        Ray ray = new Ray(transform.position, Vector3.down);
        Ray upRay = new Ray(transform.position, Vector3.up);
        if (Physics.Raycast(ray, 0.2f) || Physics.Raycast(upRay, 5f))
            transform.position += Vector3.up * 0.2f;

        this.transform.LookAt(target);
    }
}
