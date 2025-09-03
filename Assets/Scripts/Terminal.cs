using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
    //Get target references
    //Create a reference to power up the terminal

    [SerializeField] private GameObject[] _targets;
    [SerializeField] private bool _isTerminalOn;

    private bool _hasActivated;


    public void Interact()
    {
        //Get all targets
        //For all targets Activate 

        _hasActivated = true;
        Activate(_isTerminalOn);

        foreach(GameObject target in _targets)
        {
            if(target.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Activate(_hasActivated);
            }
        }
    }

    public void Activate(bool isActive)
    {
        if (!_isTerminalOn)
        {
            _isTerminalOn = true;
        }
    }
}
