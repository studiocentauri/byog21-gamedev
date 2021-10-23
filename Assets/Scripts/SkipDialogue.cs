using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogue : MonoBehaviour
{
    private Dialogue witness;

    public void SetWitness(Dialogue newWit)
    {
        witness = newWit;
    }

    public void SkipToNext()
    {
        witness.nextDialogue();
    }
}
