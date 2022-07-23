using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    [SerializeField] private Transform _itemsContainer;

    [SerializeField] private StorageSwitcher _storageSwitcher;

    [SerializeField] private StorageFill _storageFill;

    [SerializeField] private List<int> _itemsAmount;

    [SerializeField] private int _maxAmountOfOreInStorage;
    [SerializeField] private int _maxAmountOfWoodInStorage;
    [SerializeField] private int _maxAmountOfIngotInStorage;
    [SerializeField] private int _maxAmountOfPlankInStorage;
    
    public event UnityAction<int> OreStorageAmountChanged;
    public event UnityAction<int> WoodStorageAmountChanged;
    public event UnityAction<int> IngotStorageAmountChanged;
    public event UnityAction<int> PlankStorageAmountChanged;
    
    public int MaxAmountOfOreInStorage => _maxAmountOfOreInStorage - _itemsAmount[0];
    public int MaxAmountOfWoodInStorage => _maxAmountOfWoodInStorage - _itemsAmount[1];
    public int MaxAmountOfIngotInStorage => _maxAmountOfIngotInStorage - _itemsAmount[2];
    public int MaxAmountOfPlankInStorage => _maxAmountOfPlankInStorage - _itemsAmount[3];
    
    public Transform ItemContainer => _itemsContainer;

    private void OnEnable()
    {
        _storageSwitcher.ItemChanged += ShowInfo;
        _storageFill.OreStorageAdded += AddOreToStorage;
        _storageFill.WoodStorageAdded += AddWoodToStorage;
        _storageFill.IngotStorageAdded += AddIngotToStorage;
        _storageFill.PlankStorageAdded += AddPlankToStorage;
    }
    private void OnDisable()
    {
        _storageSwitcher.ItemChanged -= ShowInfo;
    }
    private void AddOreToStorage(int value)
    {
        _itemsAmount[0] += value;
        OreStorageAmountChanged?.Invoke(_itemsAmount[0]);
    }
    private void AddWoodToStorage(int value)
    {
        _itemsAmount[1] += value;
        WoodStorageAmountChanged?.Invoke(_itemsAmount[1]);
    }
    private void AddIngotToStorage(int value)
    {
        _itemsAmount[2] += value;
        IngotStorageAmountChanged?.Invoke(_itemsAmount[2]);
    }
    private void AddPlankToStorage(int value)
    {
        _itemsAmount[3] += value;
        PlankStorageAmountChanged?.Invoke(_itemsAmount[3]);
    }

    private void ShowInfo(int id)
    {
        _itemsContainer.GetChild(id).GetComponentInChildren<TextMeshProUGUI>().text = _itemsAmount[id].ToString();
    }
}
