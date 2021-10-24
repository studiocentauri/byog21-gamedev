using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueObject
{
    public string name;
    public string head_text;
    public string cook_state;
    public string servent_state;
    public string cook_perv;
    public string servent_perv;
    public bool isfound = false;
    public bool talkedtocook = false;
    public bool talkedtoservent = false;
    public string correct = "Cook";

    public ClueObject(string onName, string onHead, string servState, string cookState, string cookPerv, string servPerv, string Correct = "Cook")
    {
        name = onName;
        head_text = onHead;
        cook_state = cookState;
        servent_state = servState;
        cook_perv = cookPerv;
        servent_perv = servPerv;
        correct = Correct;
    }

    public ReportedEvent giveReportedEvent(string desc, string source)
    {
        ReportedEvent events = new ReportedEvent(name, head_text, desc, source, true);
        return events;
    }

    public ReportedEvent giveCorrectRepEvent()
    {
        ReportedEvent events = new ReportedEvent(correct, head_text, "", correct, true);
        return events;
    }

}
