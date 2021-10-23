using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventListController : MonoBehaviour
{

    public List<ReportedEvent> events = new List<ReportedEvent>(){ new ReportedEvent("Event1","Desc1","Auth1", true), new ReportedEvent("Event2", "Desc2", "Auth2",true), new ReportedEvent("Event3", "Desc3", "Auth1", true), new ReportedEvent("Event4", "Desc4", "Auth2", true), new ReportedEvent("Event5", "Desc5", "Auth1", true), new ReportedEvent("Event6", "Desc6", "Auth2", true) };

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
