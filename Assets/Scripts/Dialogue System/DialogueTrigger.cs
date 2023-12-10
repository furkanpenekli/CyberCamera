using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue _dialogue;
    private bool _selected = false;

    private int _selectedIndex = 0;
    public int selectedIndex
    {
        get { return _selectedIndex; }
        set { _selectedIndex = value; }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Player"))
        {
            if (_selected /*&& !_dialogue.isActive*/)
            {
                _dialogue.StartDialogue();
                _selected = false;
                
                if (_selected /*&& _dialogue.isActive*/)
                {
                    _dialogue.NextDialogue();
                    _selected = false;
                }
            }
        }
    }
}
