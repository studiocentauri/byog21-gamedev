using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] dialogues;

    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueText;

    int dialogueIndex = 0;

    void Awake()
    {
        dialogueBox.SetActive(false);
    }

    public void InitiateDialogue(GameObject player)
    {
        Camera.main.GetComponent<CameraMovement>().StartDialogue(this.gameObject);
        dialogueBox.SetActive(true);
        dialogueBox.transform.Find("SkipButton").gameObject.GetComponent<SkipDialogue>().SetWitness(this);
        dialogueIndex = 0;
        SetDialogue(dialogues[dialogueIndex]);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && dialogueBox.activeSelf)
        {
            ResetDialogue();
        }
    }

    void ResetDialogue()
    {
        Debug.Log("Reset pos");
        Camera.main.GetComponent<CameraMovement>().EndDialogue();
        dialogueBox.SetActive(false);
        GameObject.FindObjectOfType<ClickManager>().ResetClick();
    }

    public void nextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex >= dialogues.Length)
        {
            ResetDialogue();
        }
        else
        {
            SetDialogue(dialogues[dialogueIndex]);
        }
    }

    void SetDialogue(string text)
    {
        dialogueText.text = text;
    }
}
