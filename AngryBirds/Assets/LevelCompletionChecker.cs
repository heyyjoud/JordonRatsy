using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletionChecker : MonoBehaviour
{
    public LevelSelect levelSelect; // Reference to the LevelSelect script

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming the player triggers this script upon completing the level
            MarkLevelAsCompleted();
        }
    }

    void MarkLevelAsCompleted()
    {
        if (levelSelect != null)
        {
            // Unlock the next level in the level select scene
            levelSelect.UnlockLevel(SceneManager.GetActiveScene().buildIndex - 1); // Subtract 1 to match level indices
        }
    }
}
