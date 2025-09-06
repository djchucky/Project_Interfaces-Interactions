using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Instance is null");
            }
            return _instance;
        }
    }

    //Create a list of all inventory items
    [SerializeField] public List<AllItems> _inventoryItems = new List<AllItems>();

    //items in enum
    //Four items (Keycards)

    public enum AllItems
    {
        KeycardA,
        KeycardB,
        KeycardC,
        KeycardD
    }

    private void Awake()
    {
        _instance = this;
    }

    //Add Collected Itemms to the inventory list
    //if items is not in the list
    //Add the items

    public void AddItems(AllItems item)
    {
        if(!_inventoryItems.Contains(item))
        {
            _inventoryItems.Add(item);
        }
    }

    //Remove Collected Itemms to the inventory list
    //if items is in the list
    //Remove the items

    public void RemoveItems(AllItems item)
    {
        if (_inventoryItems.Contains(item))
        {
            _inventoryItems.Remove(item);
        }
    }
}
