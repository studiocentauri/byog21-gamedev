using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class register_clue : MonoBehaviour
{
    public bool clue_registered = false;
    public ClueList clue_list;
    public void register_this_clue()
    {
        if (!clue_registered)
        {
            clue_list.counter ++;
            //count ++
            //show in clue window with description
            //sending gameobj to cluelist to show it
            clue_list.ActivateButton(gameObject);
        }
        clue_registered = true;
    }

}
