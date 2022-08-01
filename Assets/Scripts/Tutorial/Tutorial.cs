using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> _arrowsList;

    [SerializeField] private List<GameObject> _collidersList;

    [SerializeField] private List<string> _tutorialPhrases;

    [SerializeField] private GameObject _tutorialText;

    private bool _isTutorialPlaying = true;
    
    private int _currentValue = 0;

    private int _isTutorialPlayingValue = 1;

    private void Start()
    {
        Load();
        if (_isTutorialPlaying == true)
        {
            _arrowsList[_currentValue].SetActive(true);
            _collidersList[_currentValue].SetActive(true);
            _tutorialText.GetComponentInChildren<TMP_Text>().text = _tutorialPhrases[_currentValue];
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
            _tutorialText.GetComponentInChildren<TMP_Text>().text = _tutorialPhrases[_currentValue];
        }
        else
        {
            _arrowsList[_currentValue].SetActive(false);
            _collidersList[_currentValue].SetActive(false);
            _tutorialText.SetActive(false);
            _isTutorialPlayingValue = 2;
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("IsTutorialPlaying", _isTutorialPlayingValue);
    }
    private void Load()
    {
        _isTutorialPlayingValue = PlayerPrefs.GetInt("IsTutorialPlaying", 1);

        if (_isTutorialPlayingValue == 2)
        {
            _isTutorialPlaying = false;
        }
    }
}
