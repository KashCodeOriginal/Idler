using UnityEngine;
using UnityEngine.Events;

public class StorageSwitcher : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    
    [SerializeField] private int _currentItemId;

    public int CurrentItemId => _currentItemId;
    
    public event UnityAction<int> ItemChanged;

    private void Start()
    {
        ChangeItem(1);
    }

    private void ChangeItem(int value)
    {
        if (_currentItemId >= _storage.ItemContainer.childCount - 1 && value != -1)
        {
            _currentItemId = 0;
            _storage.ItemContainer.GetChild(_storage.ItemContainer.childCount - 1).gameObject.SetActive(false);
        }
        else if (_currentItemId <= 0 && value != 1)
        {
            _storage.ItemContainer.GetChild(_currentItemId).gameObject.SetActive(false);
            _currentItemId = _storage.ItemContainer.childCount - 1;
        }
        else
        {
            _currentItemId += value;
            if (value == -1)
            {
                _storage.ItemContainer.GetChild(_currentItemId + 1).gameObject.SetActive(false);
            }
            else if (value == 1)
            {
                _storage.ItemContainer.GetChild(_currentItemId - 1).gameObject.SetActive(false);
            }
        }
        _storage.ItemContainer.GetChild(_currentItemId).gameObject.SetActive(true);
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
