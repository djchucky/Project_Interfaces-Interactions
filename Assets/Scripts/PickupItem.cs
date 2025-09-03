using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{

    public void Interact()
    {
        Debug.Log("Interact with: " + gameObject.name);
    }

    public void Activate(bool isActive)
    {
        
    }
}
