using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    [SerializeField] private Transform _itemsContainer;

    [SerializeField] private StorageSwitcher _storageSwitcher;

    [SerializeField] private StorageFill _storageFill;

    [SerializeField] private StorageCollect _storageCollect;

    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private Upgrade _upgrade;
    
    [SerializeField] private int _oreAmount;
    [SerializeField] private int _woodAmount;
    [SerializeField] private int _ingotAmount;
    [SerializeField] private int _plankAmount;

    [SerializeField] private int _maxAmountOfOreInStorage;
    [SerializeField] private int _maxAmountOfWoodInStorage;
    [SerializeField] private int _maxAmountOfIngotInStorage;
    [SerializeField] private int _maxAmountOfPlankInStorage;
    
    public event UnityAction<int> OreStorageAmountChanged;
    public event UnityAction<int> WoodStorageAmountChanged;
    public event UnityAction<int> IngotStorageAmountChanged;
    public event UnityAction<int> PlankStorageAmountChanged;
    
    public event UnityAction<int> AddOreToInventory;
    public event UnityAction<int> AddWoodToInventory;
    public event UnityAction<int> AddIngotToInventory;
    public event UnityAction<int> AddPlankToInventory;

    public event UnityAction PlacingBox;
    
    public int MaxAmountOfOreInStorage => _maxAmountOfOreInStorage - _oreAmount;
    public int MaxAmountOfWoodInStorage => _maxAmountOfWoodInStorage - _woodAmount;
    public int MaxAmountOfIngotInStorage => _maxAmountOfIngotInStorage - _ingotAmount;
    public int MaxAmountOfPlankInStorage => _maxAmountOfPlankInStorage - _plankAmount;
    
    public Transform ItemContainer => _itemsContainer;

    private void Start()
    {
        Load();
        OreStorageAmountChanged?.Invoke(_oreAmount);
        WoodStorageAmountChanged?.Invoke(_woodAmount);
        IngotStorageAmountChanged?.Invoke(_ingotAmount);
        PlankStorageAmountChanged?.Invoke(_plankAmount);
    }

    private void OnEnable()
    {
        _storageSwitcher.ItemChanged += ShowInfo;
        
        _storageFill.OreStorageAdded += AddOreToStorage;
        _storageFill.WoodStorageAdded += AddWoodToStorage;
        _storageFill.IngotStorageAdded += AddIngotToStorage;
        _storageFill.PlankStorageAdded += AddPlankToStorage;

        _storageCollect.TryGetOreStorageValue += TryGetOreAmountInStorage;
        _storageCollect.TryGetWoodStorageValue += TryGetWoodAmountInStorage;
        _storageCollect.TryGetIngotStorageValue += TryGetIngotAmountInStorage;
        _storageCollect.TryGetPlankStorageValue += TryGetPlankAmountInStorage;

        _upgrade.UpgradeStorage += UpgradeStorage;
    }
    private void OnDisable()
    {
        _storageSwitcher.ItemChanged -= ShowInfo;
        
        _storageFill.OreStorageAdded -= AddOreToStorage;
        _storageFill.WoodStorageAdded -= AddWoodToStorage;
        _storageFill.IngotStorageAdded -= AddIngotToStorage;
        _storageFill.PlankStorageAdded -= AddPlankToStorage;

        _storageCollect.TryGetOreStorageValue -= TryGetOreAmountInStorage;
        _storageCollect.TryGetWoodStorageValue -= TryGetWoodAmountInStorage;
        _storageCollect.TryGetIngotStorageValue -= TryGetIngotAmountInStorage;
        _storageCollect.TryGetPlankStorageValue -= TryGetPlankAmountInStorage;
        
        _upgrade.UpgradeStorage -= UpgradeStorage;
    }
    private void AddOreToStorage(int value)
    {
        _oreAmount += value;
        OreStorageAmountChanged?.Invoke(_oreAmount);
        PlacingBox?.Invoke();
        Save();
    }
    private void AddWoodToStorage(int value)
    {
        _woodAmount += value;
        WoodStorageAmountChanged?.Invoke(_woodAmount);
        PlacingBox?.Invoke();
        Save();
    }
    private void AddIngotToStorage(int value)
    {
        _ingotAmount += value;
        IngotStorageAmountChanged?.Invoke(_ingotAmount);
        PlacingBox?.Invoke();
        Save();
    }
    private void AddPlankToStorage(int value)
    {
        _plankAmount += value;
        PlankStorageAmountChanged?.Invoke(_plankAmount);
        PlacingBox?.Invoke();
        Save();
    }
    private void TryGetOreAmountInStorage(int value)
    {
        if (value == -1)
        {
            _playerInventory.TryGetItemValue(ref _oreAmount, _playerInventory.MaxOreInInventory, AddOreToInventory, OreStorageAmountChanged);
        }
        else
        {
            _playerInventory.TryGetItemValue(ref _oreAmount,value, _playerInventory.MaxOreInInventory, AddOreToInventory, OreStorageAmountChanged);
        }
        Save();
    }
    private void TryGetWoodAmountInStorage(int value)
    {
        if (value == -1)
        {
            _playerInventory.TryGetItemValue(ref _woodAmount, _playerInventory.MaxWoodInInventory, AddWoodToInventory, WoodStorageAmountChanged);
        }
        else
        {
            _playerInventory.TryGetItemValue(ref _woodAmount,value, _playerInventory.MaxWoodInInventory, AddWoodToInventory, WoodStorageAmountChanged);
        }
        Save();
    }
    private void TryGetIngotAmountInStorage(int value)
    {
        if (value == -1)
        {
            _playerInventory.TryGetItemValue(ref _ingotAmount, _playerInventory.MaxOreInInventory, AddIngotToInventory, IngotStorageAmountChanged);
        }
        else
        {
            _playerInventory.TryGetItemValue(ref _ingotAmount,value, _playerInventory.MaxOreInInventory, AddIngotToInventory, IngotStorageAmountChanged);
        }
        Save();
    }
    private void TryGetPlankAmountInStorage(int value)
    {
        if (value == -1)
        {
            _playerInventory.TryGetItemValue(ref _plankAmount, _playerInventory.MaxOreInInventory, AddPlankToInventory, PlankStorageAmountChanged);
        }
        else
        {
            _playerInventory.TryGetItemValue(ref _plankAmount,value, _playerInventory.MaxOreInInventory, AddPlankToInventory, PlankStorageAmountChanged);
        }
        Save();
    }

    private void ShowInfo(int id)
    {
        if (id == 0)
        {
            _itemsContainer.GetChild(id).GetComponentInChildren<TextMeshProUGUI>().text = _oreAmount.ToString();
        }
        else if (id == 1)
        {
            _itemsContainer.GetChild(id).GetComponentInChildren<TextMeshProUGUI>().text = _woodAmount.ToString();
        }
        else if (id == 2)
        {
            _itemsContainer.GetChild(id).GetComponentInChildren<TextMeshProUGUI>().text = _ingotAmount.ToString();
        }
        else if (id == 3)
        {
            _itemsContainer.GetChild(id).GetComponentInChildren<TextMeshProUGUI>().text = _plankAmount.ToString();
        }
    }

    private void UpgradeStorage()
    {
        _maxAmountOfOreInStorage += 10;
        _maxAmountOfWoodInStorage += 10;
        _maxAmountOfIngotInStorage += 10;
        _maxAmountOfPlankInStorage += 10;
        Save();
    }
    
    private void Save()
    {
        PlayerPrefs.SetInt("OreInStorage", _oreAmount);
        PlayerPrefs.SetInt("WoodInStorage", _woodAmount);
        PlayerPrefs.SetInt("IngotInStorage", _ingotAmount);
        PlayerPrefs.SetInt("PlankInStorage", _plankAmount);
        PlayerPrefs.SetInt("MaxOreInStorage", _maxAmountOfOreInStorage);
        PlayerPrefs.SetInt("MaxWoodInStorage", _maxAmountOfWoodInStorage);
        PlayerPrefs.SetInt("MaxIngotInStorage", _maxAmountOfIngotInStorage);
        PlayerPrefs.SetInt("MaxPlankInStorage", _maxAmountOfPlankInStorage);
    }
    private void Load()
    {
        _oreAmount = PlayerPrefs.GetInt("OreInStorage");
        _woodAmount = PlayerPrefs.GetInt("WoodInStorage");
        _ingotAmount = PlayerPrefs.GetInt("IngotInStorage");
        _plankAmount = PlayerPrefs.GetInt("PlankInStorage");
        _maxAmountOfOreInStorage = PlayerPrefs.GetInt("MaxOreInStorage", 20);
        _maxAmountOfWoodInStorage = PlayerPrefs.GetInt("MaxWoodInStorage", 20);
        _maxAmountOfIngotInStorage = PlayerPrefs.GetInt("MaxIngotInStorage", 20);
        _maxAmountOfPlankInStorage = PlayerPrefs.GetInt("MaxPlankInStorage", 20);
    }
}
