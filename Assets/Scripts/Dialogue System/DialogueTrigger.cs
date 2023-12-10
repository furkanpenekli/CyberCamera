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
            Debug.Log("triggered!");
            if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !isDialogueInProgress)
            {
                // Set the flag to indicate that the dialogue is now in progress
                isDialogueInProgress = true;

                // Call the dialogue system
                _dialogue.StartDialogue();
                _interactButton.SetActive(false);
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
