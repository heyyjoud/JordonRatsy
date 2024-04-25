using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelNumber; // Assign level numbers to each button in the inspector
    [SerializeField] private string nextSceneName; // Name of the scene to load next

    private void Start()
    {
        UpdateButtonState();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }

    private void UpdateButtonState()
    {
        if (IsLevelUnlocked(levelNumber))
        {
            GetComponent<Button>().interactable = true;
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Button>().interactable = false;
            GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.5f); // 50% translucent white
        }
    }

    private bool IsLevelUnlocked(int level)
    {
        return PlayerPrefs.GetInt("Level" + level + "_Completed", 0) == 1;
    }

    public void UnlockNextLevel()
    {
        // Your logic to unlock the next level
        
        // Load the next scene specified in the Inspector
        GoToNextScene();
    }
    
    private void GoToNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("No next scene specified.");
        }
    }
}
