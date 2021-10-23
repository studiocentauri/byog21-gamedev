using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class WindowSwitch : MonoBehaviour
{
    public GameObject WitnessWindow;
    public GameObject TimelineWindow;
    public UnityEngine.UI.Button Witnessbutton;
    public UnityEngine.UI.Button Timelinebutton;

    public UnityEvent onTimelineSwitch;
    public UnityEvent onWitnessSwitch;

    private void Start()
    {
        onWitnessTab();
    }

    public void onWitnessTab()
    {
        Witnessbutton.interactable = false;
        Timelinebutton.interactable = true;
        WitnessWindow.SetActive(true);
        TimelineWindow.SetActive(false);
        onWitnessSwitch.Invoke();
    }

    public void onTimelineTab()
    {
        Witnessbutton.interactable = true;
        Timelinebutton.interactable = false;
        WitnessWindow.SetActive(false);
        TimelineWindow.SetActive(true);
        onTimelineSwitch.Invoke();
    }
}
