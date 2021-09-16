using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private SnakeComposition _snakeComposition;
    [SerializeField] private Snake _snake;

    private List<Vector3> _positions = new List<Vector3>();

    private void Awake()
    {
        _positions.Add(transform.position);

        _snakeComposition._onPartAdded += _part => _positions.Add(_part.position);
        _snakeComposition._onPartRemoved += () => _positions.RemoveAt(_positions.Count - 1);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 _targetHadPosition = transform.position;
        _targetHadPosition += Vector3.forward * _snake.Speed * Time.deltaTime;
        _targetHadPosition.x = Mathf.Lerp(_targetHadPosition.x, _userInput.TargetXPosition, 0.075f);

        Quaternion _targetHadRotation = Quaternion.LookRotation(_targetHadPosition - transform.position);

        transform.position = _targetHadPosition;
        transform.rotation = _targetHadRotation;

        float _distance = Vector3.Distance(transform.position, _positions[0]);

        if (_distance > _snake.PartDistance)
        {
            Vector3 _direction = (transform.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + _direction * _snake.PartDistance);
            _positions.RemoveAt(_positions.Count - 1);
            _distance -= _snake.PartDistance;
        }

        for (int i = 0; i < _snakeComposition.PartCount; i++)
        {
            Vector3 _targetPosition = Vector3.Lerp(_positions[i + 1], _positions[i], _distance / _snake.PartDistance);
            Quaternion _rotation = Quaternion.LookRotation(_targetPosition - _positions[i + 1]);

            _snakeComposition.GetPart(i).position = _targetPosition;
            _snakeComposition.GetPart(i).rotation = _rotation;
        }
    }

}
