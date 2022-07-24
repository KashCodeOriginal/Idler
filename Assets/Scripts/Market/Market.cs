using TMPro;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private MarketItemsSwitch _marketItemsSwitcher;
    
    [SerializeField] private Transform _itemsContainer;

    [SerializeField] private int _orePrice;
    [SerializeField] private int _woodPrice;
    [SerializeField] private int _ingotPrice;
    [SerializeField] private int _plankPrice;

    [SerializeField] private TMP_Text _priceText;
    
    public Transform ItemContainer => _itemsContainer;

    private void OnEnable()
    {
        _marketItemsSwitcher.ItemChanged += ShowInfo;
    }
    private void OnDisable()
    {
        _marketItemsSwitcher.ItemChanged -= ShowInfo;
    }
    private void ShowInfo(int id)
    {
        if (id == 0)
        {
            _priceText.text = _orePrice.ToString();
        }
        else if (id == 1)
        {
            _priceText.text = _woodPrice.ToString();
        }
        else if (id == 2)
        {
            _priceText.text = _ingotPrice.ToString();
        }
        else if (id == 3)
        {
            _priceText.text = _plankPrice.ToString();
        }
    }
}
