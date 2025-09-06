using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _isLocked;
    [SerializeField] private GameObject[] _doorPanels;
    private bool _isOpen;
    private Animator _anim;

    //Designer need the ability to require an item for the door (Keycard)
    //Reference to the required item
    [SerializeField] private bool _requireItem;
    [SerializeField] private InventoryManager.AllItems _itemRequired;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Anim is null on DOOR");
        }

        if(_isLocked)
        {
            _doorPanels[0].gameObject.SetActive(true);
            _doorPanels[1].gameObject.SetActive(false);

        }
        else
        {
            _doorPanels[0].gameObject.SetActive(false);
            _doorPanels[1].gameObject.SetActive(true);
        }
    }

    public void Interact()
    {
        if (_isLocked)
        {
            if (_requireItem && CheckRequiredItem(_itemRequired))
            {
                UnlockDoor();
                return;
            }

            Debug.Log("Door is Locked, you need to unlock it");
        }
        else
        {
            _isOpen = !_isOpen;
            _anim.SetBool("IsOpen", _isOpen);
        }
    }

    public void Activate(bool hasTriggered)
    {
        if (hasTriggered)
        {
            Debug.Log("Unlock");
            UnlockDoor();
        }

        else
        {
            Debug.Log("Lock");
            LockDoor();
        }
    }

    private void UnlockDoor()
    {
        _isLocked = false;
        _doorPanels[0].gameObject.SetActive(false);
        _doorPanels[1].gameObject.SetActive(true);
    }

    private void LockDoor()
    {
        _isLocked = true;
        _isOpen = false;
        _anim.SetBool("IsOpen", _isOpen);
        _doorPanels[0].gameObject.SetActive(true);
        _doorPanels[1].gameObject.SetActive(false);

    }

    //Method to check if we have required item
    private bool CheckRequiredItem(InventoryManager.AllItems itemRequired)
    {
        bool hasItem = false;
        //Check inventory
        //if we do we unlock the door and remove item from inventory
        if(InventoryManager.Instance._inventoryItems.Contains(itemRequired))
        {
            InventoryManager.Instance.RemoveItems(itemRequired);
            hasItem = true;
        }

        return hasItem;
    }
}
