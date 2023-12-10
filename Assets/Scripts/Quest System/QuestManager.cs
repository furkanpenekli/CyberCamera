using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();
    public List<AmountQuest> amountQuests = new List<AmountQuest>();
    public static QuestManager instance;

    private void Awake()
    {
        //Sinlgeton Code
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartQuest(string questName)
    {
        Quest quest = GetQuestByName(questName);

        if (quest != null && !quest.isCompleted)
        {
            Debug.Log("Quest started: " + questName);
            // Add any specific logic for starting a quest
        }
    }

    public void CompleteQuest(string questName)
    {
        Quest quest = GetQuestByName(questName);

        if (quest != null && !quest.isCompleted)
        {
            quest.isCompleted = true;
            Debug.Log("Quest completed: " + questName);
            // Add any specific logic for completing a quest

            // Example: Grant rewards, update game state, etc.
        }
    }

    public void UpdateAmountQuestProgress(string questName, int amount)
    {
        AmountQuest quest = GetAmountQuestByName(questName);

        if (quest != null && !quest.isCompleted)
        {
            quest.currentItemCount += amount;

            // Check if the quest is now completed
            if (quest.currentItemCount >= quest.requiredItemCount)
            {
                CompleteQuest(questName);
            }
        }
    }

    private Quest GetQuestByName(string questName)
    {
        return quests.Find(quest => quest.questName == questName);
    }

    private AmountQuest GetAmountQuestByName(string questName)
    {
        return amountQuests.Find(quest => quest.questName == questName);
    }
}
