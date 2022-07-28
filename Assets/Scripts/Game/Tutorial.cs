using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> _arrowsList;

    [SerializeField] private List<GameObject> _collidersList;

    private bool _isTutorialPlaying = true;

    public bool IsTutorialPlaying => _isTutorialPlaying;

    private int _currentValue = 0;

    private void Start()
    {
        if (_isTutorialPlaying == true)
        {
            _arrowsList[_currentValue].SetActive(true);
            _collidersList[_currentValue].SetActive(true);
        }
    }

    public void ChangeValue()
    {
        if (_currentValue != _arrowsList.Count - 1)
        {
            _currentValue++;
            _arrowsList[_currentValue - 1].SetActive(false);
            _arrowsList[_currentValue].SetActive(true);
            _collidersList[_currentValue - 1].SetActive(false);
            _collidersList[_currentValue].SetActive(true);
        }
    }
}
