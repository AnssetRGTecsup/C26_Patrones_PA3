using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void ResetCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().ToString();

        SceneManager.LoadScene(currentScene);
    }

    public void LoadScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void LoadScene(int newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
