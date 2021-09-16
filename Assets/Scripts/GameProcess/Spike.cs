using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour, IInteractable
{
    [SerializeField] private GameLooper _gameLooper;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);
    }

    public void Interact(SnakeProperties _snakeProperties)
    {
        if (_snakeProperties.SnakeState == SnakeState.Normal) _gameLooper.Gameover();
        else Destroy(gameObject);
    }
}
