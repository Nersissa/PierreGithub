using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class Quest
{
    public EventHandler<EventArgs> QuestCompleted;
    public EventHandler<EventArgs> Created;

    public bool Completed { get; set; }
    public string Name { get; private set; }
    private List<QuestStep> Steps { get; set; }


    public void IsCreated()
    {
        if (Created != null)
            Created(this, new EventArgs());
    }

    public void Complete()
    {
        if (QuestCompleted != null && !Completed)
        {
            QuestCompleted(this, new EventArgs());
            Completed = true;
        }
    }

    public QuestStep GetStep(int StepNr)
    {
        return Steps[StepNr];
    }

    public int NrOfSteps
    {
        get { return Steps.Count; }
    }
    public void AddStep(QuestStep Step)
    {
        Steps.Add(Step);
        Step.IsCreated();
    }

    public Quest(string Name)
    {
        this.Name = Name;
        Steps = new List<QuestStep>();
    }
}

public class QuestStep
{
    public EventHandler<EventArgs> Created;
    public EventHandler<EventArgs> StepComplete;
    public EventHandler<EventArgs> IllegalAction;

    public void IsCreated()
    {
        if (Created != null)
            Created(this, new EventArgs());
    }

    public void NoCanDo()
    {
        if (IllegalAction != null)
            IllegalAction(this, new EventArgs());
    }

    public void Complete()
    {
        if (StepComplete != null && !Completed)
        {
            StepComplete(this, new EventArgs());
            Completed = true;
        }
    }

    public bool Completed { get; set; }
    public string Objective { get; private set; }
    public string Description { get; private set; }

    public QuestStep(string Objective, string Description)
    {
        this.Objective = Objective;
        this.Description = Description;
    }
}



