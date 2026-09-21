using UnityEngine;

public class TimeWall : MonoBehaviour
{
    private BoxCollider box;
    private Material material;
    private void OnEnable()
    {
        box = GetComponent<BoxCollider>();
        material = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    private void OnDisable()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
        material.color = new Color(0, 0, 1f, 0.5f);
    }

    void Pause()
    {
        box.enabled = true;
        material.color = new Color(1f, 0, 0, 0.5f);
    }

    void Unpause()
    {
        box.enabled = false;
        material.color = new Color(0, 0, 1f, 0.5f);
    }
}
