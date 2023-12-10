using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode _interactInput;
    [SerializeField]
    private KeyCode _hideableInput;

    private Movement _movement;
    private Hideable _hideable;
    void Start()
    {
        _movement = GetComponent<Movement>();
        _hideable = GetComponent<Hideable>();
    }
    void Update()
    {
        HorizontalInput();
        HideInput();
    }

    private void HideInput()
    {
        if (Input.GetKeyDown(_hideableInput))
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
}
