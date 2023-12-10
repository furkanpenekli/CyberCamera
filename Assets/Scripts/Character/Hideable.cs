using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour
{
    [SerializeField]
    private bool _hideable = false;
    void Start()
    {
          
    }
    void Update()
    {
        
    }

    public bool GetHidden() 
    {
        return _hideable;
    }
    public void SetHidden(bool value)
    {
        _hideable = value;
    }

}
