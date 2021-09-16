using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private SnakeColor _snakeColor;

    [SerializeField] private Color32 _pointColor;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private MeshRenderer _pointMeshRenderer;


    private void Start()
    {
        ChangePointColor();
    }

    private void ChangePointColor()
    {
        _particleSystem.startColor = _pointColor;
        _pointMeshRenderer.material.color = _pointColor;
    }

    //private void OnTriggerEnter(Collider _other)
    //{
    //    if(_other.transform.TryGetComponent(out SnakeColor _snakeColor))
    //    {
    //        _snakeColor.SetColor(_pointColor);
    //    }
    //}

    public void Interact(SnakeProperties _snakeProperties)
    {
        _snakeColor.SetColor(_pointColor);
    }
}
