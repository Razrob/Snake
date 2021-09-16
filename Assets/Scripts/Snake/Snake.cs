using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeComposition _snakeComposition;
    [SerializeField] private SuperMover _superMover;

    [SerializeField] private Transform _partPrefab;

    [SerializeField] private int _partCount;
    [SerializeField] private float _partDistance;
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _superSpeed;

    public float PartDistance => _partDistance;
    public float Speed { get; private set; }


    private void Start()
    {
        Speed = _normalSpeed;
        _superMover._onStateChanged += _snakeState => ChangeSpeed(_snakeState);

        for (int i = 0; i < _partCount; i++) _snakeComposition.AddPart(_partPrefab);
    }

    private void ChangeSpeed(SnakeState _snakeState)
    {
        if (_snakeState == SnakeState.Normal) Speed = _normalSpeed;
        else Speed = _superSpeed;
    }

    public void AddPart()
    {
        _partCount++;
        _snakeComposition.AddPart(_partPrefab);
    }
}
