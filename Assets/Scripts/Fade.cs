using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator fade;
    private int buildindex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FadeOut(int levelIndex)
    {
        buildindex = levelIndex;
        fade.SetTrigger("FadeOut");
    }
    public void Play()
    {
        SceneManager.LoadScene(buildindex);
    }
}
