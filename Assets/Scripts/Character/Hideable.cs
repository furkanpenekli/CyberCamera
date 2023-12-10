using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    private bool _hidden = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public bool GetHidden() 
    {
        return _hidden;
    }
    public void SetHidden(bool value)
    {
        _hidden = value;
    }

}
