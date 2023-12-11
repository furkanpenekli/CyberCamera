using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _interactButton;
    [SerializeField]
    private Dialogue _dialogue;

    private bool isDialogueInProgress = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !isDialogueInProgress)
            {
                // Set the flag to indicate that the dialogue is now in progress
                isDialogueInProgress = true;

                if (!_dialogue.endDialogue)
                {
                    FindObjectOfType<DialogueManager>().currentDialogue = _dialogue;
                    FindObjectOfType<DialogueManager>().currentDialogue.StartDialogue();
                }

                else if (_dialogue.endDialogue && _dialogue.nextDialogue != null)
                {
                    if (QuestManager.instance.GetAmountQuestByName(_dialogue._amountQuestName).isCompleted)
                    {
                        FindObjectOfType<DialogueManager>().currentDialogue = _dialogue.nextDialogue;
                        FindObjectOfType<DialogueManager>().currentDialogue.StartDialogue();
                    }
                }
                
                
                // Call the dialogue system

                if (_interactButton != null)
                {
                    _interactButton.SetActive(false);
                }
            }
        }
    }
    private void Update()
    {
        
    }
    public void CheckEndedDialogue()
    {
        if (_dialogue != null)
        {
            if (_dialogue.endDialogue)
            {
                EndDialogue();
            }
        }
    }
    // Assuming you have a method to handle the end of the dialogue, you can reset the flag there
    public void EndDialogue()
    {
        _interactButton.SetActive(true);
        isDialogueInProgress = false;
    }
}
