using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour, IInteractable
{
    [SerializeField] private GameLooper _gameLooper;

    [SerializeField] private Color32 _peopleColor;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Snake _snake;

    private void Start()
    {
        _meshRenderer.material.color = _peopleColor;
    }

    private bool CheckEatAvailability(SnakeProperties _snakeProperties)
    {
        return _peopleColor.r == _snakeProperties.SnakeColor.r &&
            _peopleColor.g == _snakeProperties.SnakeColor.g &&
            _peopleColor.b == _snakeProperties.SnakeColor.b;
    }

    private void Eat()
    {
        _snake.AddPart();
        _gameLooper.AddPeople(1);
        Destroy(gameObject);
    }

    public void Interact(SnakeProperties _snakeProperties)
    {
        if (CheckEatAvailability(_snakeProperties) || _snakeProperties.SnakeState == SnakeState.SuperMove) Eat();
        else _gameLooper.Gameover();
    }

}
