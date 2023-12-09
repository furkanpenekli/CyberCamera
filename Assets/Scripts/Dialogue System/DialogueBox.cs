using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{
    [SerializeField]
    private Image _head;

    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _textComponent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateHead(Image head)
    {
        if (_head == null)
            _head = head;
    }
    public void UpdateName(string text)
    {
        if (_name != null)
            _name.text = text;
    }
    public void UpdateText(string text)
    {
        if (_textComponent != null)
            _textComponent.text = text;
    }
}
