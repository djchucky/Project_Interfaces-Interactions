using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    private Transform _cameraTransform;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;

    }


    private void LateUpdate()
    {
        //LookAt Method to change the orientation of the UI
        //on a specific Axis

        transform.LookAt(_cameraTransform);
    }
}
