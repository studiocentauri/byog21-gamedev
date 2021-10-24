using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highlight_old : MonoBehaviour
{
    public Material highlight_material;

    public mouse_cursor mouseCursor;
    //public ButtonClick clue_register;
    //public Transform clicked_selection;

    public GameObject clue_info_canvas;
    public TextMeshProUGUI clue_name;
    public TextMeshProUGUI clue_description;

    Transform selection;

    private void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.transform;
            if (selection.CompareTag("clue"))
            {
                mouseCursor.cursor_on_clue();// change cursor sprite
                if (Input.GetButtonDown("Fire1"))// highlight on click + clue info + add to clues found
                {
                    var selection_renderer = selection.GetComponent<Renderer>();
                    if (selection_renderer != null)
                    {
                        selection_renderer.material = highlight_material;
                    }
                    //clue description
                    if (selection.name == "blood")
                    {
                        clue_found("blood");
                        clue_name.text = "spool of blood outside the cupboard";
                        clue_description.text = "bahut saara blood outside the cupboard was found.";
                    }
                    else if (selection.name == "broken vase")
                    {
                        clue_found("broken vase");
                        clue_name.text = "broken vase";
                        clue_description.text = "daku must be in hurry. broken vase.";
                    }
                }
            }
            else mouseCursor.change_cursor_to_default();
        }
        else mouseCursor.change_cursor_to_default();

    }
    void clue_found(string clue_name)
    {
        clue_info_canvas.SetActive(true);
        selection.GetComponent<register_clue>().register_this_clue();
        //clue count ++
        //add that clue on found clues list
    }


}
