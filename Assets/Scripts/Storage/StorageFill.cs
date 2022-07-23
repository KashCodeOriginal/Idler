using UnityEngine;
using UnityEngine.Events;

public class StorageFill : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;
    [SerializeField] private Storage _storage;
    [SerializeField] private StorageSwitcher _storageSwitcher;
    [SerializeField] private ValueSwitcher _valueSwitcher;

    public event UnityAction<int, int> TryGetOreInventoryValue;
    public event UnityAction<int, int> TryGetWoodInventoryValue;
    public event UnityAction<int, int> TryGetIngotInventoryValue;
    public event UnityAction<int, int> TryGetPlankInventoryValue;

    public event UnityAction<int> OreStorageAdded;
    public event UnityAction<int> WoodStorageAdded;
    public event UnityAction<int> IngotStorageAdded;
    public event UnityAction<int> PlankStorageAdded;

    public void StorageFillAll()
    {
        GameObject _item = _storage.ItemContainer.GetChild(_storageSwitcher.CurrentItemId).gameObject;
        switch (_item.GetComponent<StorageItem>().ItemType)
        {
            case StorageItem.Item.Ore:
                TryGetOreInventoryValue?.Invoke(_storage.MaxAmountOfOreInStorage, -1);
                break;
            case StorageItem.Item.Wood:
                TryGetWoodInventoryValue?.Invoke(_storage.MaxAmountOfWoodInStorage, -1);
                break;
            case StorageItem.Item.Ingot:
                TryGetIngotInventoryValue?.Invoke(_storage.MaxAmountOfIngotInStorage, -1);
                break;
            case StorageItem.Item.Plank:
                TryGetPlankInventoryValue?.Invoke(_storage.MaxAmountOfPlankInStorage, -1);
                break;
        }
    }
    public void StorageFillValue()
    {
        GameObject _item = _storage.ItemContainer.GetChild(_storageSwitcher.CurrentItemId).gameObject;
        int value = _valueSwitcher.CurrentValue;
        switch (_item.GetComponent<StorageItem>().ItemType)
        {
            case StorageItem.Item.Ore:
                TryGetOreInventoryValue?.Invoke(_storage.MaxAmountOfOreInStorage, value);
                break;
            case StorageItem.Item.Wood:
                TryGetWoodInventoryValue?.Invoke(_storage.MaxAmountOfWoodInStorage, value);
                break;
            case StorageItem.Item.Ingot:
                TryGetIngotInventoryValue?.Invoke(_storage.MaxAmountOfIngotInStorage, value);
                break;
            case StorageItem.Item.Plank:
                TryGetPlankInventoryValue?.Invoke(_storage.MaxAmountOfPlankInStorage, value);
                break;
        }
    }

    private void OnEnable()
    {
        _playerInventory.AddOreToStorage += AddOreToStorage;
        _playerInventory.AddWoodToStorage += AddWoodToStorage;
        _playerInventory.AddIngotToStorage += AddIngotToStorage;
        _playerInventory.AddPlankToStorage += AddPlankToStorage;
    }
    private void OnDisable()
    {
        _playerInventory.AddOreToStorage -= AddOreToStorage;
        _playerInventory.AddWoodToStorage -= AddWoodToStorage;
        _playerInventory.AddIngotToStorage -= AddIngotToStorage;
        _playerInventory.AddPlankToStorage -= AddPlankToStorage;
    }

    private void AddOreToStorage(int value)
    {
        OreStorageAdded?.Invoke(value);
    }
    private void AddWoodToStorage(int value)
    {
        WoodStorageAdded?.Invoke(value);
    }
    private void AddIngotToStorage(int value)
    {
        IngotStorageAdded?.Invoke(value);
    }
    private void AddPlankToStorage(int value)
    {
        PlankStorageAdded?.Invoke(value);
    }
}
