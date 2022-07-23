using UnityEngine;
using UnityEngine.Events;

public class StorageCollect : MonoBehaviour
{
    [SerializeField] private Storage _storage;
    [SerializeField] private StorageSwitcher _storageSwitcher;
    [SerializeField] private ValueSwitcher _valueSwitcher;
    
    public event UnityAction<int> TryGetOreStorageValue;
    public event UnityAction<int> TryGetWoodStorageValue;
    public event UnityAction<int> TryGetIngotStorageValue;
    public event UnityAction<int> TryGetPlankStorageValue;
    
    public void StorageCollectAll()
    {
        GameObject _item = _storage.ItemContainer.GetChild(_storageSwitcher.CurrentItemId).gameObject;
        switch (_item.GetComponent<StorageItem>().ItemType)
        {
            case StorageItem.Item.Ore:
                TryGetOreStorageValue?.Invoke(-1);
                break;
            case StorageItem.Item.Wood:
                TryGetWoodStorageValue?.Invoke(-1);
                break;
            case StorageItem.Item.Ingot:
                TryGetIngotStorageValue?.Invoke(-1);
                break;
            case StorageItem.Item.Plank:
                TryGetPlankStorageValue?.Invoke(-1);
                break;
        }
    }
    public void StorageCollectValue()
    {
        GameObject _item = _storage.ItemContainer.GetChild(_storageSwitcher.CurrentItemId).gameObject;
        int value = _valueSwitcher.CurrentValue;
        switch (_item.GetComponent<StorageItem>().ItemType)
        {
            case StorageItem.Item.Ore:
                TryGetOreStorageValue?.Invoke(value);
                break;
            case StorageItem.Item.Wood:
                TryGetWoodStorageValue?.Invoke(value);
                break;
            case StorageItem.Item.Ingot:
                TryGetIngotStorageValue?.Invoke(value);
                break;
            case StorageItem.Item.Plank:
                TryGetPlankStorageValue?.Invoke(value);
                break;
        }
    }
}
