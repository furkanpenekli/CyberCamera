using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue _dialogue;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("triggered!");
            if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
            {
                Debug.Log("triggeredgfiidfifi!");
                _dialogue.StartDialogue();
            }
        }
    }
}
