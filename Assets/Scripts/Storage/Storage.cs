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
    }
    private void AddWoodToStorage(int value)
    {
        _woodAmount += value;
        WoodStorageAmountChanged?.Invoke(_woodAmount);
        PlacingBox?.Invoke();
    }
    private void AddIngotToStorage(int value)
    {
        _ingotAmount += value;
        IngotStorageAmountChanged?.Invoke(_ingotAmount);
        PlacingBox?.Invoke();
    }
    private void AddPlankToStorage(int value)
    {
        _plankAmount += value;
        PlankStorageAmountChanged?.Invoke(_plankAmount);
        PlacingBox?.Invoke();
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
    }
}
