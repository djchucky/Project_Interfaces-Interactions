using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCore : MonoBehaviour,IInteractable
{
    //Check if picked up and dropped
    private bool _pickedUp;

    //Update the position of the power core to a pickup transform on the player
    [SerializeField] private Transform _pickupTransform;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.LogError("Rigidbody is NULL on PowerCore");
        }
    }

    public void Interact()
    {
        if(!_pickedUp)
        {
            _pickedUp = !_pickedUp;
            //Turn of Physics gravity when picked up
            _rb.isKinematic = true;
            Debug.Log("Picked up item");

            //Set the player has the parent
            transform.position = _pickupTransform.position;
            transform.rotation = _pickupTransform.rotation;
            transform.SetParent(_pickupTransform.parent);
        }
        else
        {
            _pickedUp = !_pickedUp;
            _rb.isKinematic = false;

            //Reset the parent back to the world on drop
            transform.SetParent(null);
            //_rb.AddForce(_pickupTransform.gameObject.transform.forward * 5, ForceMode.Impulse);
        }
    }

    public void Activate(bool isActive)
    {
        
    }
}
