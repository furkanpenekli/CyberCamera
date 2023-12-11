using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCode : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && QuestManager.instance.GetAmountQuestByName("Anahtar").isCompleted)
        {
            //oyun bitecek
        }
    }
}
