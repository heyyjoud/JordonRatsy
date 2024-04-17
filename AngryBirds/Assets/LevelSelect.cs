using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons; // Array of buttons representing levels
    public Color lockedColor; // Color for locked buttons
    private bool[] levelUnlocked; // Array indicating whether each level is unlocked

    void Start()
    {
        // Initialize levelUnlocked array based on saved values or default values
        levelUnlocked = new bool[levelButtons.Length];
        
        // Load saved level completion data or set default values if not found
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = PlayerPrefs.GetInt("Level" + i, 0) == 1;
        }

        // Check if either story or start button has been pressed
        if (PlayerPrefs.GetInt("StoryButtonPressed", 0) == 1 || PlayerPrefs.GetInt("StartButtonPressed", 0) == 1)
        {
            // Unlock levels if either button has been pressed
            UnlockAllLevels();
        }

        // Update UI to reflect unlocked levels
        UpdateLevelUI();
    }

    // Function to update UI based on unlocked levels
    void UpdateLevelUI()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // Enable or disable each button based on whether its corresponding level is unlocked
            levelButtons[i].interactable = levelUnlocked[i];

            // Adjust alpha value based on lock state
            Color buttonColor = levelButtons[i].colors.normalColor;
            buttonColor.a = levelUnlocked[i] ? 1f : 0.5f; // Set alpha to 1 if unlocked, otherwise reduce alpha
            ColorBlock colors = levelButtons[i].colors;
            colors.normalColor = buttonColor;
            levelButtons[i].colors = colors;
        }
    }

    // Function to unlock a level
    public void UnlockLevel(int levelIndex)
    {
        // Mark the specified level as unlocked
        if (levelIndex < levelUnlocked.Length)
        {
            levelUnlocked[levelIndex] = true;
            // Save the updated level completion state
            PlayerPrefs.SetInt("Level" + levelIndex, 1);
            PlayerPrefs.Save();
            // Update UI to reflect the change
            UpdateLevelUI();
        }
    }

    // Function to unlock all levels
    public void UnlockAllLevels()
    {
        for (int i = 0; i < levelUnlocked.Length; i++)
        {
            levelUnlocked[i] = true;
            PlayerPrefs.SetInt("Level" + i, 1);
        }
        PlayerPrefs.Save();
        UpdateLevelUI();
    }

    // Function to change scene by level index
    public void ChangeSceneByLevelIndex(int levelIndex)
    {
        if (levelUnlocked[levelIndex])
        {
            SceneManager.LoadScene(levelIndex + 1); // Assuming level index 0 corresponds to scene index 1 (to skip main menu)
        }
        else
        {
            Debug.Log("Level " + levelIndex + " is locked!");
            // You can display a message or take any other action if the level is locked
        }
    }
}
