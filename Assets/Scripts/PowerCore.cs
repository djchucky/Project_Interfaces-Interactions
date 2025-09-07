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
    public int powerLevel;

    private Material _mat;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if(_rb == null)
        {
            Debug.LogError("Rigidbody is NULL on PowerCore");
        }

        _mat = GetComponentInChildren<Renderer>().material;
    }

    public void Interact()
    {
        if(!_pickedUp)
        {
            _pickedUp = !_pickedUp;

            //Turn of Physics gravity when picked up
            _rb.isKinematic = true;

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
        }
    }

    public void Activate(bool isActive)
    {
        
    }

    public void ChangeLevelColor(int powerLevelRequired)
    {
        float percentage = ((float)powerLevel/powerLevelRequired  * 100);
        int powerLevelPercentage = Mathf.RoundToInt(percentage);

        Debug.Log($"Percentage is: {powerLevelPercentage}");

        switch(powerLevelPercentage)
        {
            case int n when n < 30:
                GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.magenta);
                break;

            case int n when n < 60:
                GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                break;

            case int n when n < 90:
                GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.cyan);
                break;

            case int n when n == 100:
                GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.green);
                break;

            case int n when n > 100:
                GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.red);
                break;

            default:
                break;
        }
    }

    public void ResetBaseColor()
    {
        GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", Color.black);
    }
}
