using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueList : MonoBehaviour
{
    public int counter =0;
    public GameObject[] ClueLists;

    public void ActivateButton(GameObject SelectedButton)
    {
        string Name = SelectedButton.name;
        ClueLists[counter-1].transform.Find(Name).gameObject.SetActive(true);
    }

}
