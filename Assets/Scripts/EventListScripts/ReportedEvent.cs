using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportedEvent
{
    public string eventHead;
    public string eventDesc;
    public string Source;
    public bool found = false;

    public ReportedEvent(string EventHead, string EventDesc, string source, bool Found = false)
    {
        eventHead = EventHead;
        eventDesc = EventDesc;
        Source = source;
        found = Found;
    }
}
