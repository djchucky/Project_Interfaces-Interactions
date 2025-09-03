using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    //Reference to detect if chest is open
    //Reference to animator
    //Add key functionality
    //Interactable Interface

    private bool _hasInteracted;

    private bool _isOpen;
    [SerializeField] private bool _isLocked;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Anim is null on Chest");
        }
    }

    public void Interact()
    {
        if(_isLocked)
        {
            Debug.Log("You need to unlock");
            return;
        }

        _hasInteracted = true;
        _isOpen = !_isOpen;
        ChangeDoorStatus(_isOpen);

        //Spawn Loot
        if(TryGetComponent<SpawnLoot>(out SpawnLoot spawnLoot))
        {
            spawnLoot.Spawn();
        }

    }

    public void Activate(bool hasTriggered)
    {
        if(hasTriggered)
        _isLocked = true;
    }

    private void ChangeDoorStatus(bool IsOpen)
    {
        _anim.SetBool("IsOpen", IsOpen);
    }
}
