using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Fade fade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        fade.FadeOut(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
