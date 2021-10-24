using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class clue_info_highlight : MonoBehaviour
{
    public GameObject clue_info_canvas;

    private GameObject currentClue;

    public Color hightlightColor;

    private Color originalColor;

    public TextMeshProUGUI clue_name;

    public TextMeshProUGUI clue_description;

    public List<ClueObject> clues = new List<ClueObject>() {
            new ClueObject("fingerprint","Fingerprints of Cook on the bedroom lock","When he left the place to go out for buy stuff, Mr X was doing fine, the bedroom wasn�t locked and when he left, the apartment had Cook and Mr. X only."," Mr X wasn�t feeling well, so he wanted to get a nap and thus, he had closed his bedroom door for silence. His fingerprints are there because he had entered the bedroom in the morning.","",""),
            new ClueObject("knife","Fingerprints of Cook on the bedroom lock","The knife belongs to the same house and is used by the cook for all kitchen purposes.","Mr X has asked for a fruit and knife to cut it.The knife has been present there since the morning.","",""),
            new ClueObject("plate","Pieces of broken plate","He can�t claim much about the plate. But his intuition says the plate was broken in the struggle between Mr X and the Killer.","It�s the same plate in which he served the fruits.Maybe it would have fallen by accident.","","","Servent"),
            new ClueObject("window","Room adjacent to bedroom has a Broken Window Pane","The window was broken last week and was about to be repaired soon.","He rarely enters the other room, since Mr X used to stay mostly in his bedroom and his work was to serve him food only.So, there was no point going to that room.","",""),
            new ClueObject("blood","Bathroom open with blood stains at the door","Mr X never left his bathroom door opened.","The blood stains on the door can imply a fight.But he didn�t hear any water taps open while he was working around.","",""),
            new ClueObject("shirt","Oversized Shirt Noticed","Mr X had a few shirts that he wore only when he felt a bit uneasy.","Mr X never wore oversized clothes.Moreover he had seen a similar shirt once on the servant","",""),
            new ClueObject("witness","Witness interrogation","Witness 1 - Neighbour - Heard noise of glass breaking around 2:15 PM - But didn�t came out to check","Witness 1 - Neighbour - Heard noise of glass breaking around 2:15 PM - But didn�t came out to check","",""),
            new ClueObject("cut","Cut identified at servant�s hand","He got that cut while he was working on Mr X�s car.","He didn�t notice the servant's hand.","",""),
        };

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

        Camera.main.gameObject.GetComponent<CameraMovement>().StartInspect(clue);
        clue.GetComponent<register_clue>().register_this_clue();
        //clue count ++
        //add that clue on found clues list

        foreach (ClueObject obj in clues)
        {
            if (obj.name == clue_name.text)
            {
                clue_name.text = obj.head_text;
                obj.isfound = true;
            }
        }
    }

    public void HideUI()
    {
        clue_info_canvas.SetActive(false);
        currentClue.GetComponent<Renderer>().material.color = originalColor;
        Camera.main.gameObject.GetComponent<CameraMovement>().EndInspect();
        GameObject.Find("ClickManager").GetComponent<ClickManager>().ResetClick();
    }

}
