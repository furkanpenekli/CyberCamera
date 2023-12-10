using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    //last dialogue text can be display if base dialogue already read
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

