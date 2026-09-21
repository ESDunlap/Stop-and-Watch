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
            if (!((Mathf.Sign(rotateVertical) == -1) && (this.transform.localPosition.y) > 5))
                transform.localPosition -= Vector3.up * rotateVertical * Time.deltaTime * 100f;
            //((Mathf.Sign(rotateVertical) == -1) && (this.transform.localPosition.y) > -1000))
        }

        transform.localPosition -= Vector3.forward * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel") * 1000f;

        //Makes sure the camera does not go into the ground or ceiling
        if (Physics.Raycast(transform.position - Vector3.up * 0.2f, Vector3.up, out var inGround) && !Physics.Raycast(transform.position - Vector3.up * 0.2f, Vector3.down))
            transform.localPosition += Vector3.up * inGround.distance;
        if (Physics.Raycast(transform.position, Vector3.forward, out var preventForwardInObject, 1f))
        {
            transform.localPosition -= Vector3.forward * preventForwardInObject.distance;
        }
        if (Physics.Raycast(transform.position, Vector3.back, out var preventBackInObject, 1f))
        {
            transform.localPosition -= Vector3.back * preventBackInObject.distance;
        }
        /*if (Physics.Raycast(transform.position + Vector3.up * 0.3f, Vector3.down, out var inObjectVertically, 0.5f))
        {
            transform.position = inObjectVertically.point + Vector3.up * 0.5f;
        }*/
        if (Physics.Raycast(transform.position, Vector3.up, out var preventUpInObject, 1f))
        {
            transform.localPosition -= Vector3.up * preventUpInObject.distance;
        }
        if (Physics.Raycast(transform.position, Vector3.down, out var preventDownInObject, 1f))
        {
            transform.localPosition -= Vector3.down * preventDownInObject.distance;
        }
        //if (Physics.Raycast(transform.position + Vector3.right * 0.5f, Vector3.right)



        this.transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = transform.position;
    }
}
