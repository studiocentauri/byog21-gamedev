using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventListController : MonoBehaviour
{

    public List<ReportedEvent> events = new List<ReportedEvent>();

    public List<ReportedEvent> getFoundEvents()
    {
        List<ReportedEvent> foundevents = new List<ReportedEvent>();
        foreach (ReportedEvent item in events)
        {
            if(item.found)
            {
                foundevents.Add(item);
            }
        }
        return foundevents;
    }
}
