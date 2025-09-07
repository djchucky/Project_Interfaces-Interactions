using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerReceiver : PowerBase
{
    //Inherit from the powerbase
    //Allow designer to input required level
    //Check if powerlevel is sufficient
    //Check if powerCore is on the receiver
    //Have a target to be powered up by receiver

    private bool _isActive;
    [SerializeField] private int _levelRequired;
    [SerializeField] private GameObject _target;

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
      
        if(collision.gameObject.TryGetComponent<PowerCore>(out PowerCore powerCore))
        {
            powerCore.ChangeLevelColor(_levelRequired);

            if(powerCore.powerLevel == _levelRequired)
            {
                _isActive = true;
                Debug.Log("Amount enough");
                _target.GetComponent<IInteractable>().Activate(_isActive);
            }
            else if (powerCore.powerLevel > _levelRequired)
            {
                Debug.Log("Too Much Power");
            }

            else
            {
                Debug.Log("You need more power");
            }
        }
    }

    public override void OnCollisionExit(Collision other)
    {
        base.OnCollisionExit(other);
        _isActive = false;
        if(other.gameObject.TryGetComponent<PowerCore>(out PowerCore powerCore))
        {
            powerCore.ResetBaseColor();
        }

    }

}
