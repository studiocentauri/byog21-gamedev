using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TimeLineEvent : MonoBehaviour
{
    public string id;
    public string eventHead;
    public string eventDesc;
    public string Source;
    public int position;
    public TimelinePageController timecontroller;
    bool isOnTimeline;

    public TMPro.TMP_Text text;

    public void copyFromTimelineEvent(ReportedEvent repEvent, int Position, TimelinePageController controller, bool ontimeline = false)
    {
        id = repEvent.id;
        eventHead = repEvent.eventHead;
        eventDesc = repEvent.eventDesc;
        Source = repEvent.Source;
        position = Position;
        timecontroller = controller;
        isOnTimeline = ontimeline;


        setVals();
    }

    void setVals()
    {
        text.text = String.Format("{0}'s Statement \n {1}",Source,eventDesc);
    }

    public void onSwitchClicked()
    {
        timecontroller.SwitchCol(position, isOnTimeline);
    }

    public void onUpClicked()
    {
       if(position >= 1)
        {
            timecontroller.swapEvent(position - 1, isOnTimeline);
        }
    }

    public void onDownClicked()
    {
        timecontroller.swapEvent(position, isOnTimeline);
    }
}
