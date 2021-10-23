using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WitnessEvent : MonoBehaviour
{
    public TMPro.TMP_Text text;

    public void copyFromReportedEV(ReportedEvent events)
    {
        text.text = events.eventHead + events.eventDesc;
    }
}
