using System;
using UnityEngine;
using UnityEngine.Events;

public class SellToMarket : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private MarketItemSwitch _marketItemSwitch;

    [SerializeField] private Market _market;

    public event UnityAction GetOreValueInInventory;
    public event UnityAction GetWoodValueInInventory;
    public event UnityAction GetIngotValueInInventory;
    public event UnityAction GetPlankValueInInventory;

    public event UnityAction<int> CoinsAmountChanged;
    
    public event UnityAction PlacingBox;
    
    public void SellItem()
    {
        switch (_marketItemSwitch.CurrentItemId)
        {
            case 0:
                GetOreValueInInventory?.Invoke();
                break;
            case 1:
                GetWoodValueInInventory.Invoke();
                break;
            case 2:
                GetIngotValueInInventory?.Invoke();
                break;
            case 3:
                GetPlankValueInInventory?.Invoke();
                break;
        }
    }

    private void OnEnable()
    {
        _playerInventory.SellOre += SellOre;
        _playerInventory.SellWood += SellWood;
        _playerInventory.SellIngot += SellIngot;
        _playerInventory.SellPlank += SellPlank;
    }
    private void OnDisable()
    {
        _playerInventory.SellOre -= SellOre;
        _playerInventory.SellWood -= SellWood;
        _playerInventory.SellIngot -= SellIngot;
        _playerInventory.SellPlank -= SellPlank;
    }

    private void SellOre(int value)
    {
        CoinsAmountChanged?.Invoke(value * _market.OrePrice);
        PlacingBox?.Invoke();
    }
    private void SellWood(int value)
    {
        
        CoinsAmountChanged?.Invoke(value * _market.WoodPrice);
        PlacingBox?.Invoke();
    }
    private void SellIngot(int value)
    {
        CoinsAmountChanged?.Invoke(value * _market.IngotPrice);
        PlacingBox?.Invoke();
    }
    private void SellPlank(int value)
    {
        CoinsAmountChanged?.Invoke(value * _market.PlankPrice);
        PlacingBox?.Invoke();
    }
}
