using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode _interactInput;
    [SerializeField]
    private KeyCode _hideInput;

    private Movement _movement;
    private Player _player;
    private Hideable _hideable;
    void Start()
    {
        _movement = GetComponent<Movement>();
        _player = GetComponent<Player>();
    }
    void Update()
    {
        HorizontalInput();
        InteractDialogue();
    }

    private void HideInput()
    {
        if (Input.GetKeyDown(_hideInput))
        {
            _hideable.SetHidden(!_hideable.GetHidden());
        }
    }

    private void HorizontalInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (_movement != null)
        {
            _movement.horizontalSpeed = horizontalInput;
        }
    }
    private void InteractDialogue()
    {
        if (Input.GetKeyDown(_interactInput))
        {
            _player.InteractDialogue();
        }
    }
}
