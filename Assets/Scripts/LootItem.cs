using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour, IInteractable
{
    //Reference to our Inventory Manager
    [SerializeField] private InventoryManager.AllItems _itemType;

    //Interact with the Item
    public void Interact()
    {
        //Add this item to the Inventory
        //Destroy GameObject
        InventoryManager.Instance.AddItems(_itemType);
        Destroy(gameObject);
        
    }

    //Add Activate Code
    public void Activate(bool isActive)
    {
        
    }
}
