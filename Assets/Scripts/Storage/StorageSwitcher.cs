using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items;
    
    [SerializeField] private int _currentItemId;

    public event UnityAction<int> ItemChanged;

    private void Start()
    {
        ChangeItem(1);
    }

    private void ChangeItem(int value)
    {
        if (_currentItemId >= _items.Count - 1 && value != -1)
        {
            _currentItemId = 0;
            _items[_items.Count - 1].SetActive(false);
        }
        else if (_currentItemId <= 0 && value != 1)
        {
            _items[_currentItemId].SetActive(false);
            _currentItemId = _items.Count - 1;
        }
        else
        {
            _currentItemId += value;
            if (value == -1)
            {
                _items[_currentItemId + 1].SetActive(false);
            }
            else if (value == 1)
            {
                _items[_currentItemId - 1].SetActive(false);
            }
        }
        _items[_currentItemId].SetActive(true);
        ItemChanged?.Invoke(_currentItemId);
    }

    public void NextItem()
    {
        ChangeItem(1);
    }

    public void PreviousItem()
    {
        ChangeItem(-1);
    }
    
}
