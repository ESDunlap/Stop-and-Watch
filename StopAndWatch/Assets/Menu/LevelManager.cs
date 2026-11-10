using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private PauseOptions _pauseOptions;
    public void LoadSelectedLevel(int levelNumber)
    {
        _pauseOptions = FindFirstObjectByType<PauseOptions>();
        if ( _pauseOptions != null )
            _pauseOptions.Unpause();
        SceneManager.LoadScene(levelNumber);
    }
}
