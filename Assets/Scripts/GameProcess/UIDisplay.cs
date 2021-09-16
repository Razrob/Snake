using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private Text _crystalCounter;
    [SerializeField] private Text _peopleCounter;

    [SerializeField] private GameLooper _gameLooper;

    [SerializeField] private GameObject _gameoverPanel;
    [SerializeField] private GameObject _finishPanel;

    private void Start()
    {
        _gameLooper._onCrystalCountChanged += _value => _crystalCounter.text = $"Кристаллы: {_value}";
        _gameLooper._onPeopleCountChanged += _value => _peopleCounter.text = $"Человечки: {_value}";
    }

    public void SetGameoverPanelDisplay(bool _enabled)
    {
        _gameoverPanel.SetActive(_enabled);
    }

    public void SetFinishPanelDisplay(bool _enabled)
    {
        _finishPanel.SetActive(_enabled);
    }

}
