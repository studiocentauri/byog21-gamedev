using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clue_info_highlight : MonoBehaviour
{
    public GameObject clue_info_canvas;

    private GameObject currentClue;

    public Color hightlightColor;

    private Color originalColor;

    public TextMeshProUGUI clue_name;

    public TextMeshProUGUI clue_description;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HideUI();
        }
    }

    public void clue_found(GameObject clue)
    {
        clue_info_canvas.SetActive(true);
        currentClue = clue;
        originalColor = currentClue.GetComponent<Renderer>().material.color;
        currentClue.GetComponent<Renderer>().material.color = hightlightColor;
        clue_name.text = clue.name;
        clue_description.text = "Random description for " + clue.name;
        Camera.main.gameObject.GetComponent<CameraMovement>().StartInspect(clue);
        //clue count ++
        //add that clue on found clues list
    }

    public void HideUI()
    {
        clue_info_canvas.SetActive(false);
        currentClue.GetComponent<Renderer>().material.color = originalColor;
        Camera.main.gameObject.GetComponent<CameraMovement>().EndInspect();
        GameObject.Find("ClickManager").GetComponent<ClickManager>().ResetClick();
    }

}
