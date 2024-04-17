using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStoryButtonPressed()
    {
        PlayerPrefs.SetInt("StoryButtonPressed", 1); // Set flag for story button press
        PlayerPrefs.Save(); // Save PlayerPrefs changes
    }

    public void OnStartButtonPressed()
    {
        PlayerPrefs.SetInt("StartButtonPressed", 1); // Set flag for start button press
        PlayerPrefs.Save(); // Save PlayerPrefs changes
    }
}


