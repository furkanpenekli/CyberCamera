using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    private void Update()
    {
        // Check if the 'E' key is pressed and the '_isActive' flag is true
        if (Input.GetKeyDown(KeyCode.E) && _isActive)
        {
            NextMassage();
        }

        // Set the active state of the current game object based on the '_isActive' flag
        gameObject.SetActive(_isActive);
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
        //last dialogue text can be display if base dialogue already read => currentDialogueTexts.Length - 1
        if (activeDialougeText < currentDialogueTexts.Length - 1 && _isActive)
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
