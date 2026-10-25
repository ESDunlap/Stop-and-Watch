using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    [SerializeField] private GameObject instructions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Completed()
    {
        Animation removal = instructions.GetComponent<Animation>();
        removal.Play("RemoveText");
    }

    void DisableSelf()
    {
        this.gameObject.SetActive(false);
    }
}
