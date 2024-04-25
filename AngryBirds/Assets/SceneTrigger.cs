using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [SerializeField] private string levelMapSceneName; // Name of the level map scene to transition to

    public void UnlockLevelAndLoadScene(int levelNumber)
    {
        // Your logic to unlock the specified level
        PlayerPrefs.SetInt("Level" + levelNumber + "_Completed", 1);
        
        // Load the level map scene
        SceneManager.LoadScene(levelMapSceneName);
    }
}
