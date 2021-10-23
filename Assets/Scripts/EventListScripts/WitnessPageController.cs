using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitnessPageController : MonoBehaviour
{
    public EventListController eventlistcont;

    List<ReportedEvent> AEvent = new List<ReportedEvent>();
    List<ReportedEvent> BEvent = new List<ReportedEvent>();

    public GameObject Acontent;
    public GameObject Bcontent;

    public GameObject witnessEvent;

    public void fetchData()
    {
        AEvent.Clear();
        BEvent.Clear();
        foreach(ReportedEvent i in eventlistcont.getFoundEvents())
        {
            if(i.Source == "Auth1")
            {
                AEvent.Add(i);
            }
            else
            {
                BEvent.Add(i);
            }
        }
    }

    public void StartWitnessPage()
    {
        fetchData();
        ResetWitnessPage();
    }

    public void ResetWitnessPage()
    {

        for (int i = 0; i < AEvent.Count; i++)
        {
            Debug.Log("Instantiated");
            GameObject itemtime = Instantiate(witnessEvent);
            itemtime.transform.SetParent(Acontent.transform);
            itemtime.GetComponent<WitnessEvent>().copyFromReportedEV(AEvent[i]);
        }

        for (int j = 0; j < BEvent.Count; j++)
        {
            GameObject itemtime = Instantiate(witnessEvent);
            itemtime.transform.SetParent(Bcontent.transform);
            itemtime.GetComponent<WitnessEvent>().copyFromReportedEV(BEvent[j]);
        }
    }

    public void EndWitnessPage()
    {

        for (int i = 0; i < Acontent.transform.childCount; i++)
        {
            Destroy(Acontent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < Bcontent.transform.childCount; i++)
        {
            Destroy(Bcontent.transform.GetChild(i).gameObject);
        }
    }
}
