using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SnakeMover _snake;
    [SerializeField] private SuperMover _superMover;

    public float TargetXPosition { get; private set; }
    private bool _controlActive = true;

    private void Start()
    {
        _superMover._onStateChanged += _snakeState => ChangedControl(_snakeState);
    }

    private void Update()
    {
        
        if(_controlActive && Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            RaycastHit _hit;
            if (Physics.Raycast(_camera.ScreenPointToRay(_touch.position), out _hit))
            {
                 TargetXPosition = _hit.point.x;
            }
        }

    }

    private void ChangedControl(SnakeState _snakeState)
    {
        if (_snakeState == SnakeState.Normal) _controlActive = true;
        else
        {
            _controlActive = false;
            TargetXPosition = 0;
        }
    }
}
