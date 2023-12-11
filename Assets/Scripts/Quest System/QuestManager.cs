﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public List<AmountQuest> amountQuests = new List<AmountQuest>();
    public List<ExploreAreaQuest> exploreAreaQuests = new List<ExploreAreaQuest>();
    public static QuestManager instance;

    private void Awake()
    {
        //Singleton Code
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //start functions
    public void StartQuest(string questName)
    {
        Quest quest = GetQuestByName(questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.startedQuest = true;
            Debug.Log("Quest started: " + questName);
            // Add any specific logic for starting a quest
        }
    }
    
    public void StartAmountQuest(string questName)
    {
        AmountQuest quest = GetAmountQuestByName(questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.startedQuest = true;
            Debug.Log("Amount Quest started: " + questName + ". Required item count: " + quest.requiredItemCount);
            // Add specific start quest logic
        }
    }
    public void StartExploreAreaQuest(string questName, string areaToExplore)
    {
        ExploreAreaQuest quest = GetExploreAreaQuestByName(questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.startedQuest = true;
            Debug.Log("Explore Area Quest started: " + questName + ". Area to explore: " + areaToExplore);
        }
    }

    //unique functions
    public void UpdateAmountQuestProgress(string questName, int amount)
    {
        AmountQuest quest = GetAmountQuestByName(questName);

        if (quest != null && !quest.isCompleted)
        {
            quest.currentItemCount += amount;

            // Check if the quest is now completed
            if (quest.currentItemCount >= quest.requiredItemCount)
            {
                CompleteAmountQuest(questName);
            }
        }
    }
    //complete quest functions
    public void CompleteQuest(string questName)
    {
        Quest quest = GetQuestByName(questName);

        if (quest.startedQuest && quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + questName);
            // Add any specific logic for completing a quest

            // Example: Grant rewards, update game state, etc.
        }
    }
    public void CompleteAmountQuest(string questName)
    {
        AmountQuest quest = GetAmountQuestByName(questName);

        if (quest.startedQuest && quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + questName);
            // Add any specific logic for completing a quest

            // Example: Grant rewards, update game state, etc.
        }
    }
    public void CompleteExploreAreaQuest(string questName)
    {
        ExploreAreaQuest quest = GetExploreAreaQuestByName(questName);

        if (quest.startedQuest && quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + questName);
            // Add any specific logic for completing a quest

            // Example: Grant rewards, update game state, etc.
        }
    }
    //Get name functions
    public Quest GetQuestByName(string questName)
    {
        return quests.Find(quest => quest.questName == questName);
    }
    public AmountQuest GetAmountQuestByName(string questName)
    {
        return amountQuests.Find(quest => quest.questName == questName);
    }
    public ExploreAreaQuest GetExploreAreaQuestByName(string questName)
    {
        return exploreAreaQuests.Find(quest => quest.questName == questName);
    }
}
