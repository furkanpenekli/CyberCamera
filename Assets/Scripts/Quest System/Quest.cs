using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool startedQuest = false;
    public bool isCompleted;
    public string questName;
    public string description;

    public Quest(string name, string desc)
    {
        questName = name;
        description = desc;
        isCompleted = false;
        
    }
}

[System.Serializable]
public class AmountQuest : Quest
{
    public int requiredItemCount;
    public int currentItemCount;
    public AmountQuest(string name, string desc, int requiredItemCount) : base(name, desc)
    {
        this.requiredItemCount = requiredItemCount;
        currentItemCount = 0;
    }
}

[System.Serializable]
public class ExploreAreaQuest : Quest
{
    public Transform areaPointToExplore;

    public ExploreAreaQuest(string name, string desc, int requiredItemCount, Transform areaPoint)
        : base(name, desc)
    {
        areaPointToExplore = areaPoint;
    }
}
