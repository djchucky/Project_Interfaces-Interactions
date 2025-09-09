using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private StarterAssetsInputs _starterAssetsInput;
    [SerializeField] private GameObject _uIContainer;
    private bool _isInteracting;
    private IInteractable _interactable;
  
    private void Awake()
    {
        _starterAssetsInput = GameObject.FindWithTag("Player").GetComponent<StarterAssetsInputs>();
        _uIContainer.SetActive(false);
        _interactable = GetComponent<IInteractable>();
    }

    private void Update()
    {
        if (_isInteracting)
        {
           //Interaction Code
           if (_starterAssetsInput.interact)
           {
                Debug.Log("Interacting");
                _interactable.Interact();
           } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Show UI
            _uIContainer.SetActive(true);
            _isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           //Disable UI
           _uIContainer.SetActive(false);
            _isInteracting = false;
        }
    }
}
