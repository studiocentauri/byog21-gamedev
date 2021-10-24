using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    List<string> dialogues = new List<string>();

    public GameObject dialogueBox;

    public TextMeshProUGUI dialogueText;

    public bool iscook = true;
    private bool hasDialogues = false;
    public clue_info_highlight cluesArray;
    public EventListController eventController;

    int dialogueIndex = 0;

    void Awake()
    {
        dialogueBox.SetActive(false);
    }

    public void InitiateDialogue()
    {
        Camera.main.GetComponent<CameraMovement>().StartDialogue(this.gameObject);
        dialogueBox.SetActive(true);
        dialogueBox.transform.Find("SkipButton").gameObject.GetComponent<SkipDialogue>().SetWitness(this);
        dialogueIndex = 0;

        foreach (ClueObject clue in cluesArray.clues)
        {
            if (clue.isfound)
            {
                if (iscook)
                {
                    if (!clue.talkedtocook)
                    {
                        hasDialogues = true;
                        dialogues.Add(clue.cook_state);
                        clue.talkedtocook = true;
                        eventController.events.Add(clue.giveReportedEvent(clue.cook_state, "Cook"));
                    }
                }
                else
                {
                    if (!clue.talkedtoservent)
                    {
                        hasDialogues = true;
                        dialogues.Add(clue.servent_state);
                        clue.talkedtoservent = true;
                        eventController.events.Add(clue.giveReportedEvent(clue.servent_state, "Servent"));
                    }
                }
            }
        }
        if (!hasDialogues)
        {
            ResetDialogue();
            hasDialogues = false;
            return;
        }
        hasDialogues = false;
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
        if (dialogueIndex >= dialogues.Count)
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
