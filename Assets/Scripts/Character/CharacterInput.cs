using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    private Movement _movement;
    void Start()
    {
        _movement = GetComponent<Movement>();       
    }
    void Update()
    {
        HorizontalInput();
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
