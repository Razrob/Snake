using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColor : MonoBehaviour
{
    [SerializeField] private SnakeComposition _snakeComposition;
    [SerializeField] private float _changeColorTime;
    [SerializeField] private Color32 _currentColor;

    public Color32 CurrentColor { get { return _currentColor; } private set { _currentColor = value; } }

    private void Start()
    {
        transform.GetComponent<MeshRenderer>().material.color = _currentColor;
    }

    private IEnumerator SmoothChangeColor()
    {
        yield return new WaitForSeconds(_changeColorTime);

        for (int i = 0; i < _snakeComposition.PartCount; i++)
        {
            _snakeComposition.GetPart(i).GetComponent<MeshRenderer>().material.color = CurrentColor;
            yield return new WaitForSeconds(_changeColorTime);
        }
    }

    public void SetColor(Color32 _color)
    {
        CurrentColor = _color;
        transform.GetComponent<MeshRenderer>().material.color = CurrentColor;
        StartCoroutine(SmoothChangeColor());
    }
}
