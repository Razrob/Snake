using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SnakeComposition : MonoBehaviour
{
    [SerializeField] private SnakeColor _snakeColor;

    private List<Transform> _parts = new List<Transform>();

    public event Action<Transform> _onPartAdded;
    public event Action _onPartRemoved;

    public int PartCount => _parts.Count;


    public void AddPart(Transform _part)
    {
        _parts.Add(Instantiate(_part, PartCount > 0 ? _parts[_parts.Count - 1].position : transform.position, Quaternion.identity, transform));
        _parts[_parts.Count - 1].GetComponent<MeshRenderer>().material.color = _snakeColor.CurrentColor;
        _onPartAdded?.Invoke(_part);
    }

    public void RemovePart()
    {
        Destroy(_parts[_parts.Count - 1].gameObject);
        _parts.RemoveAt(_parts.Count - 1);
        _onPartRemoved?.Invoke();

    }

    public Transform GetPart(int _partIndex)
    {
        if (_partIndex >= PartCount) return null;

        return _parts[_partIndex];
    }
}
