using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offcet;

    [SerializeField] private bool _moveX;
    [SerializeField] private bool _moveY;
    [SerializeField] private bool _moveZ;


    private void FixedUpdate()
    {
        Vector3 _newPosition = _offcet;

        if (_moveX) _newPosition.x = _target.position.x + _offcet.x;
        if (_moveY) _newPosition.y = _target.position.y + _offcet.y;
        if (_moveZ) _newPosition.z = _target.position.z + _offcet.z;

        transform.position = _newPosition;
    }
}
