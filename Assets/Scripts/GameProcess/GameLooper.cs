using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLooper : MonoBehaviour
{
    [SerializeField] private UIDisplay _UIDisplay;
    [SerializeField] private SuperMover _superMover;

    private int _crystalCount;
    private int _peopleCount;

    public event Action<int> _onCrystalCountChanged;
    public event Action<int> _onPeopleCountChanged;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddCrystals(int _value)
    {
        _crystalCount += _value;

        if(_crystalCount == 5)
        {
            _crystalCount = 0;
            _superMover.BeginSuperMove();
        }

        _onCrystalCountChanged?.Invoke(_crystalCount);
    }
    public void AddPeople(int _value)
    {
        _peopleCount += _value;
        _onPeopleCountChanged?.Invoke(_peopleCount);
    }
    public void Gameover()
    {
        Time.timeScale = 0;
        _UIDisplay.SetGameoverPanelDisplay(true);
    }

    public void FinishGame()
    {
        Time.timeScale = 0;
        _UIDisplay.SetFinishPanelDisplay(true);
    }
}
