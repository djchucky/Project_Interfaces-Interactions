using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractInputExtention : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInputs;

    private void Awake()
    {
        _starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void LateUpdate()
    {
        _starterAssetsInputs.interact = false;
    }
}
