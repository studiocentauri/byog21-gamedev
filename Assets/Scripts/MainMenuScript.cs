using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void ContinueGame(){
        SceneManager.LoadScene(2);
    }

    public void HelpScene(){
        SceneManager.LoadScene(1);
    }

    public void ReturnMenu(){
        SceneManager.LoadScene(0);
    }
}
