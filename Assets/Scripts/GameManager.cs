using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sceneCount;

    void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    void LoadGameScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ResetScene()
    {
        LoadGameScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (sceneIndex >= sceneCount)
        {
            sceneIndex = 0;
        }
        LoadGameScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        LoadGameScene(0);
    }

}
