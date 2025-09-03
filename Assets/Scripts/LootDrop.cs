using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    //Reference to rigidbody
    //Use Physics to push item out of chest
    //USe Physics to spin item out of chest


    private Rigidbody _rb;
    [SerializeField] private float _force = 50f;
    [SerializeField] private float _torqueValue = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if( _rb == null)
        {
            Debug.LogError("Rigidbody is null on LootDrop");
        }

        _rb.AddForce(new Vector3(Random.Range(-2f,2f),_force,Random.Range(-2f,2f)), ForceMode.Impulse);
        _rb.AddTorque(new Vector3(Random.Range(-1f, 2f), _torqueValue, Random.Range(-2f, 2f)), ForceMode.Impulse);
    }
}
