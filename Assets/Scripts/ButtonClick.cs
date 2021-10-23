using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour
{
    public bool ButtonWasClicked=false;
    public ClueList Clue;
    public GameObject ClickedButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
   {
       if(ButtonWasClicked==false) Clue.counter+=1;
       ButtonWasClicked=true;
       ClickedButton = EventSystem.current.currentSelectedGameObject;
       Clue.ActivateButton(ClickedButton);
        if (ClickedButton != null)
           Debug.Log("Clicked on : " + ClickedButton.name);
         else
           Debug.Log("currentSelectedGameObject is null");
    }
}
