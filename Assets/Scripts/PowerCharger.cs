using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCharger : PowerBase
{
    //Inherit from powerbase
    //Detect collisions from powercore
    //Apply the powerlevel to powercore

    [SerializeField] private PowerLevel _powerLevel;

    public override void OnCollisionEnter (Collision collision)
    {
        base.OnCollisionEnter (collision);
        if((collision.gameObject.CompareTag("PowerCore")))
        {
            PowerCore powerCore = collision.gameObject.GetComponent<PowerCore>();

            _powerLevel.Apply(collision);
        }
    }
}
