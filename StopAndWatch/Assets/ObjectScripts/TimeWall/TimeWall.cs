using UnityEngine;

public class TimeWall : MonoBehaviour
{
    private BoxCollider box;
    private Material _material;
    private void OnEnable()
    {
        box = GetComponent<BoxCollider>();
        _material = gameObject.GetComponent<MeshRenderer>().material;
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    private void OnDisable()
    {
        TimeBus.Subscribe(TimeType.PAUSE, Pause);
        TimeBus.Subscribe(TimeType.UNPAUSE, Unpause);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), box);
        }
    }

    void Pause()
    {
        box.enabled = true;
        _material.color = new Color(1f, 0, 0, 0.5f);
        _material.DisableKeyword("_EMISSION");
    }

    void Unpause()
    {
        box.enabled = false;
        _material.color = new Color(0, 0, 1f, 0.5f);
        _material.EnableKeyword("_EMISSION");
    }
}
