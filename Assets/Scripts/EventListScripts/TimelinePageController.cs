using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TimelinePageController : MonoBehaviour
{
    public EventListController eventlistcont;

    List<ReportedEvent> Allevents = new List<ReportedEvent>();
    List<ReportedEvent> Timeline = new List<ReportedEvent>();

    public GameObject timelineevent;

    public GameObject alleventContent;
    public GameObject timelineeventContent;

    public void fetchData()
    {
        Allevents = eventlistcont.getFoundEvents();

        foreach(ReportedEvent eventhas in Timeline)
        {
            if(Allevents.Contains(eventhas))
            {
                Allevents.Remove(eventhas);
            }
        }
    }

    public void resetTimePage()
    {
        for (int i = 0; i < Allevents.Count; i++)
        {
            GameObject itemtime = Instantiate(timelineevent);
            itemtime.transform.SetParent(alleventContent.transform);
            itemtime.GetComponent<TimeLineEvent>().copyFromTimelineEvent(Allevents[i], i, this);
        }

        for (int j = 0; j < Timeline.Count; j++)
        {
            GameObject itemtime = Instantiate(timelineevent);
            itemtime.transform.SetParent(timelineeventContent.transform);
            itemtime.GetComponent<TimeLineEvent>().copyFromTimelineEvent(Timeline[j], j, this, true);
        }
    }

    public void StartTimelinePage()
    {
        fetchData();
        resetTimePage();
    }


    public void EndTimelinePage()
    {

        for (int i = 0; i < timelineeventContent.transform.childCount; i++)
        {
            Destroy(timelineeventContent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < alleventContent.transform.childCount; i++)
        {
            Destroy(alleventContent.transform.GetChild(i).gameObject);
        }
    }

    static void Swap<T>(IList<T> list, int indexA, int indexB)
    {
        T tmp = list[indexA];
        list[indexA] = list[indexB];
        list[indexB] = tmp;
    }

    public void swapEvent(int topindex, bool isOnTimeline)
    {
        if (isOnTimeline && Timeline.Count >= 2 && topindex + 1 < Timeline.Count)
        {
            Swap(Timeline, topindex, topindex + 1);
        }
        else if (!isOnTimeline && Allevents.Count >= 2 && topindex + 1 < Allevents.Count)
        {
            Swap(Allevents, topindex, topindex+1);
        }
        EndTimelinePage();
        resetTimePage();
    }

    public void SwitchCol(int position, bool isOnTimeline)
    {
        if(isOnTimeline)
        {
            Allevents.Add(Timeline[position]);
            Timeline.Remove(Timeline[position]);
        }
        else
        {
            Timeline.Add(Allevents[position]);
            Allevents.Remove(Allevents[position]);
        }
        EndTimelinePage();
        resetTimePage();
    }

    public void OnTest()
    {
        List<ReportedEvent> Correct = new List<ReportedEvent>() { new ReportedEvent("Event1", "Desc1", "Auth1", true), new ReportedEvent("Event2", "Desc2", "Auth2", true) };

        if (Correct == Timeline)
        {
            Debug.Log("Correct Match");
        }
        else
        {
            Debug.Log("Incorrect Match");
        }

    }

}
