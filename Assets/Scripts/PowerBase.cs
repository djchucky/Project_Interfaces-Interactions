using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBase : MonoBehaviour
{
    public virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PowerCore"))
        {
            Debug.Log("PowerCore detected");
            collision.transform.position = transform.position;
            collision.transform.rotation = transform.rotation;
        }
    }

    public virtual void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("PowerCore"))
        {
            Debug.Log("PowerCore removed");
        }

    }
}
