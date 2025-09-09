using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour, IInteractable
{
    //Multi Levels
    //Drive the speed
    //Check if's actvated
    //Check which level current
    //Determine which level to go next
    //Move the elevator to the next position

    private int _currentLevel;
    private bool _hasPower;
    private Coroutine _moveRoutine;

    [SerializeField] private float _elevatorSpeed;
    [SerializeField] private int _startingIndex;
    [SerializeField] private int _maxLevelIndex;
    [SerializeField] private Transform[] _levelsPosition;

    //Reference to player input
    //Reference to the Elevator UI

    private PlayerInput _playerInput;
    [SerializeField] GameObject _elevatorUI;

    private void Awake()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _currentLevel = _startingIndex;
        _maxLevelIndex = _levelsPosition.Length - 1;
    }

    public void Interact()
    {
        _elevatorUI.SetActive(true);
        _playerInput.SwitchCurrentActionMap("UI");
        //Show Elevator UI
        //Activate UI Action Map

        //MoveElevator();

    }

    private void MoveElevator()
    {
        if (_hasPower)
        {
            _currentLevel++;
            Debug.Log("Current floor is: " + _currentLevel);
            if (_currentLevel <= _maxLevelIndex)
            {
                if (_moveRoutine == null)
                {
                    _moveRoutine = StartCoroutine(MoveElevator(_levelsPosition[_currentLevel]));
                    return;
                }
            }

            _currentLevel = 0;

            if (_moveRoutine == null)
            {
                _moveRoutine = StartCoroutine(MoveElevator(_levelsPosition[_currentLevel]));
            }
        }
        else
        {
            Debug.Log("Need power to activate");
        }
    }

    public void Activate(bool isActive)
    {
        _hasPower = isActive;
    }

    IEnumerator MoveElevator(Transform target)
    {
        while (Vector3.Distance(transform.position, target.position) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, _elevatorSpeed * Time.deltaTime);
                yield return null;
            }

        _moveRoutine = null;
        Debug.Log("Move routine is null");
    }

    //new method to check floor integer value from onclick event
    //Choose the floor
    //Hide the UI
    //Switch action map back to player
    //Move Elevator

    public void ChooseFloor(int floorIndex)
    {
        _moveRoutine = StartCoroutine(MoveElevator(_levelsPosition[floorIndex]));
        _elevatorUI.SetActive(false);
        _playerInput.SwitchCurrentActionMap("Player");
    }


}
