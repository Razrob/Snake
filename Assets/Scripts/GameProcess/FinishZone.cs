using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameLooper _gameLooper;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.TryGetComponent(out Snake _snake)) _gameLooper.FinishGame();
    }
}
