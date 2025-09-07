using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    bool _hasPower;

    public void Interact()
    {
        if(_hasPower)
        {
            Debug.Log("Move Platform");
        }
        else
        {
            Debug.Log("Need power to activate");
        }
    }

    public void Activate(bool isActive)
    {
        _hasPower = isActive;
    }
}
