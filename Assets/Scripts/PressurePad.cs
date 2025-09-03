using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private GameObject[] _targets;
    private List<IInteractable> _interactables = new List<IInteractable>();

    private bool _hasTriggered;

    private void Start()
    {
        foreach (var target in _targets)
        {
            var interactables = target.GetComponents<IInteractable>(); // prende tutti
            foreach (var interactable in interactables)
            {
                _interactables.Add(interactable);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _hasTriggered = true;
        Trigger(other, _hasTriggered);
    }

    private void OnTriggerExit(Collider other)
    {
        _hasTriggered = false;
        Trigger(other,_hasTriggered);
    }

    private void Trigger(Collider other,bool hasTriggered)
    {
        if (_interactables != null && other.CompareTag("Pad"))
        {
            foreach(var interactable in _interactables)
            {
                interactable.Activate(hasTriggered);
            }       
        }
    }
}
