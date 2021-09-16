using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable
{
    [SerializeField] private GameLooper _gameLooper;
    [SerializeField] private int _nominal = 1;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _rotateSpeed);
    }

    private void Eat()
    {
        _gameLooper.AddCrystals(_nominal);
        Destroy(gameObject);
    }

    public void Interact(SnakeProperties _snakeProperties)
    {
        Eat();
    }
}