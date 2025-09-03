using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Change Health;
            Debug.Log("Player has entered");
            
            //Destroy
            Destroy(this.gameObject);
        }
    }
}
