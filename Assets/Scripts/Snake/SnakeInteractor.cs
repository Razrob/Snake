using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInteractor : MonoBehaviour
{
    [SerializeField] private SnakeColor _snakeColor;
    [SerializeField] private SuperMover _superMover;

    [SerializeField] private GameLooper _gameLooper;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.TryGetComponent(out IInteractable _eaten)) _eaten.Interact(new SnakeProperties { SnakeColor = _snakeColor.CurrentColor, SnakeState = _superMover.SnakeState });
    }
}
