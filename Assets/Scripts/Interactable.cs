using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _uIContainer;
    private bool _isInteracting;
    private IInteractable _interactable;
  
    private void Awake()
    {
        _uIContainer.SetActive(false);
        _interactable = GetComponent<IInteractable>();
    }

    private void Update()
    {
        if (_isInteracting)
        {
           //Interaction Code
           if (Input.GetKeyDown(KeyCode.E))
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
