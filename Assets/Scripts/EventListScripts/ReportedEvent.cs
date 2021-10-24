using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportedEvent
{
    public string id;
    public string eventHead;
    public string eventDesc;
    public string Source;
    public bool found = false;

    public ReportedEvent(string ID, string EventHead, string EventDesc, string source, bool Found = false)
    {
        id = ID;
        eventHead = EventHead;
        eventDesc = EventDesc;
        Source = source;
        found = Found;
    }

    public static bool isEqual(ReportedEvent a, ReportedEvent b)
    {
        return (a.id == b.id);
    }
}
