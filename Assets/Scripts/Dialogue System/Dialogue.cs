using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
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

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(dialogueTexts,actors);
    }
}

