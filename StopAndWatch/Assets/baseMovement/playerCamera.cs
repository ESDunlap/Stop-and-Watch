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
        if (Input.GetMouseButton(1))
        {
            float rotateVertical = Input.GetAxis("Mouse Y");
            if ((Mathf.Sign(rotateVertical) == 1) && (this.transform.localPosition.y) < 5 ||
                ((Mathf.Sign(rotateVertical) == -1) && (this.transform.localPosition.y) > 0))
                transform.position -= Vector3.down * rotateVertical * 0.2f;
            /*if (-Mathf.Sign(rotateVertical) * this.transform.rotation.y <= 70)
            {
                this.transform.RotateAround(target.transform.position, Vector3.right, -rotateVertical * Time.deltaTime * controller.sensitivity);
            }*/
        }
        this.transform.LookAt(target);
    }
}
