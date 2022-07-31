using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Market : MonoBehaviour
{
    [SerializeField] private Transform _itemsContainer;

    public Transform ItemsContainer => _itemsContainer;

    [SerializeField] private MarketItemSwitch _marketItemSwitch;

    [SerializeField] private TMP_Text _price;

    [SerializeField] private int _orePrice;
    [SerializeField] private int _woodPrice;
    [SerializeField] private int _ingotPrice;
    [SerializeField] private int _plankPrice;

    public int OrePrice => _orePrice;
    public int WoodPrice => _woodPrice;
    public int IngotPrice => _ingotPrice;
    public int PlankPrice => _plankPrice;
    
    private void OnEnable()
    {
        _marketItemSwitch.ItemChanged += ShowInfo;
    }
    private void OnDisable()
    {
        _marketItemSwitch.ItemChanged -= ShowInfo;
    }
    private void ShowInfo(int id)
    {
        if (id == 0)
        {
            _price.text = "Price: " + _orePrice;
        }
        else if (id == 1)
        {
            _price.text = "Price: " + _woodPrice;
        }
        else if (id == 2)
        {
            _price.text = "Price: " + _ingotPrice;
        }
        else if (id == 3)
        {
            _price.text = "Price: " + _plankPrice;
        }
    }
}
    
