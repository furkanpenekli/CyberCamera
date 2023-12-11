using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Dialogue nextDialogue;
    public string _amountQuestName;

    public DialogueText[] dialogueTexts;
    public Actor[] actors;

    [System.Serializable]
    public class DialogueText
    {
        public int actorID;
        public string text;
    }

    [System.Serializable]
    public class Actor
    {
        public string name;
        public Sprite sprite;
    }

    public bool endDialogue = false;
    public void StartDialogue()
    {
        if (_amountQuestName != null)
        {
            if (!QuestManager.instance.GetAmountQuestByName(_amountQuestName).isCompleted)
            {
                FindObjectOfType<DialogueManager>().OpenDialogue(dialogueTexts, actors);
                QuestManager.instance.StartAmountQuest(_amountQuestName);
            }

        }
        else
        {
            FindObjectOfType<DialogueManager>().OpenDialogue(dialogueTexts, actors);
        }
    }
}

