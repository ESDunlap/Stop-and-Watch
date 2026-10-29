using UnityEngine;

public class TutorialBlockChildren : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.GetComponent<MeshRenderer>().material = transform.parent.GetComponent<MeshRenderer>().material;
    }
}
