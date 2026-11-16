using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit : MonoBehaviour
{
    public WinScreen winScreen;

    private void Awake()
    {
        winScreen = FindFirstObjectByType<WinScreen>(FindObjectsInactive.Include);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            winScreen.gameObject.SetActive(true);
        }
    }
}
