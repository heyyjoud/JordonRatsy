using UnityEngine;
using UnityEngine.UI;  // Required for UI elements like Slider

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;  // Assign this in the inspector
    public Slider volumeSlider;       // Assign this in the inspector

    void Start()
    {
        // Optionally, initialize slider position from saved settings
        volumeSlider.value = PlayerPrefs.GetFloat("masterVolume", 0.5f);
    }

    // Call this method when the settings button is pressed
    public void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    // Call this method when the slider value changes
    public void OnVolumeChange()
    {
        // Set the volume based on the slider's value
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("masterVolume", volumeSlider.value);
    }
}
