using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMover : MonoBehaviour
{
    [SerializeField] private float _superMoveTime;

    private SnakeState _snakeState = SnakeState.Normal;

    public SnakeState SnakeState => _snakeState;

    public event Action<SnakeState> _onStateChanged;

    private IEnumerator SuperMoveTimer()
    {
        yield return new WaitForSeconds(_superMoveTime);

        _onStateChanged?.Invoke(SnakeState.Normal);

        yield return new WaitForSeconds(1f);
        FinishSuperMove();
    }

    private void FinishSuperMove()
    {
        _snakeState = SnakeState.Normal;
    }

    public void BeginSuperMove()
    {
        _snakeState = SnakeState.SuperMove;
        StartCoroutine(SuperMoveTimer());

        _onStateChanged?.Invoke(_snakeState);
    }

}
