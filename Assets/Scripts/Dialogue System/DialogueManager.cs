using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Dialogue;

public class DialogueManager : MonoBehaviour
{
    public Sprite actorSprite;
    public Text actorName;
    public Text dialogueText;
    public GameObject dialogueBox;

    DialogueText[] currentDialogueTexts;
    Actor[] currentActors;
    int activeDialougeText = 0;

    private bool _isActive = false;
    public bool isActive
    {
        get { return _isActive; }
    }


    public void OpenDialogue(DialogueText[] dialogueTexts, Actor[] actors)
    {
        currentDialogueTexts = dialogueTexts;
        currentActors = actors;
        activeDialougeText = 0;

        _isActive = true;

        Debug.Log("Started dialogue.Loaded dialogue texts" + currentDialogueTexts);
        DisplayDialogueText();
    }

    private void DisplayDialogueText()
    {
        DialogueText dialogueTextToDisplay = currentDialogueTexts[activeDialougeText];
        dialogueText.text = dialogueTextToDisplay.text;

        Actor actorToDisplay = currentActors[dialogueTextToDisplay.actorID];
        actorSprite = actorToDisplay.sprite;
        actorName.text = actorToDisplay.name;
    }

    public void NextMassage()
    {
        activeDialougeText++;
        
        if (activeDialougeText < currentDialogueTexts.Length)
        {
            DisplayDialogueText();
        }
        else
        {
            _isActive = false;
            Debug.Log("Dialogue ended!");
        }
    }
}
