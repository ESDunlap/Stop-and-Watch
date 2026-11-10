using UnityEngine;
using UnityEngine.UIElements;

public class TilingFix : MonoBehaviour
{
    private Material _material;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _material = GetComponent<MeshRenderer>().material;
        float xScale = transform.localScale.x;
        float yScale = transform.localScale.z;
        _material.mainTextureScale = new Vector2(xScale/10, yScale/10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
