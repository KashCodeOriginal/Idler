using UnityEngine;
using UnityEngine.Events;

public class MarketItemSwitch : MonoBehaviour
{
    [SerializeField] private Market _market;
    
    [SerializeField] private int _currentItemId;

    public int CurrentItemId => _currentItemId;
    
    public event UnityAction<int> ItemChanged;

    private void Start()
    {
        ChangeItem(1);
    }

    private void ChangeItem(int value)
    {
        if (_currentItemId >= _market.ItemsContainer.childCount - 1 && value != -1)
        {
            _currentItemId = 0;
            _market.ItemsContainer.GetChild(_market.ItemsContainer.childCount - 1).gameObject.SetActive(false);
        }
        else if (_currentItemId <= 0 && value != 1)
        {
            _market.ItemsContainer.GetChild(_currentItemId).gameObject.SetActive(false);
            _currentItemId = _market.ItemsContainer.childCount - 1;
        }
        else
        {
            _currentItemId += value;
            if (value == -1)
            {
                _market.ItemsContainer.GetChild(_currentItemId + 1).gameObject.SetActive(false);
            }
            else if (value == 1)
            {
                _market.ItemsContainer.GetChild(_currentItemId - 1).gameObject.SetActive(false);
            }
        }
        _market.ItemsContainer.GetChild(_currentItemId).gameObject.SetActive(true);
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
