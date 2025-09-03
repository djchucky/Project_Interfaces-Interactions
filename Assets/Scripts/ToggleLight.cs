using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour, IInteractable
{
    //Reference to material MeshRenderer
    //Toggle light functionality
    //Functionality for designer (On or off at the beginning)

    private Renderer _renderer;
    [SerializeField] private bool _isActive;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        if(_renderer == null)
        {
            Debug.LogError("Renderer is NULL on Light");
        }

        Activate(_isActive);
    }

    public void Interact()
    {
        //_isActive = !_isActive;
        Activate(_isActive);
    }

    public void Activate(bool isActive)
    {
        _isActive = !isActive;
        //Debug.Log("toggle light");
        if (!isActive)
        {
            foreach (Material mat in _renderer.materials)
            {
                mat.DisableKeyword("_EMISSION");
            }
        }
        else
        {
            foreach (Material mat in _renderer.materials)
            {
                mat.EnableKeyword("_EMISSION");
            }
        }
    }
}
