using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemQuest : MonoBehaviour
{
    [SerializeField]
    private string _amountQuestName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (QuestManager.instance.GetAmountQuestByName(_amountQuestName).startedQuest)
            {
                QuestManager.instance.UpdateAmountQuestProgress(_amountQuestName, 1);
                Destroy(gameObject);
            } 
        }
    }
}
