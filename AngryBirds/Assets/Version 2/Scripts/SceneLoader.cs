using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GoToNextScene()
    {
        GoToScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToTitleScene()
    {
        GoToScene(0);
    }

    public void ReloadCurrentScene()
    {
        GoToScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void gameOverScene()
    {
        Debug.Log("yoohoo");
        GoToScene(3);
    }
}

