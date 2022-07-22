using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ResourcesCreation _resourcesCreation;
    
    [SerializeField] private Fabric _fabric;

    [SerializeField] private int _oreAmount;
    [SerializeField] private int _woodAmount;
    
    [SerializeField] private int _maxOreAmountInOnventory;
    [SerializeField] private int _maxWoodAmountInOnventory;
    
    [SerializeField] private int _ingotAmount;
    [SerializeField] private int _plankAmount;
    
    [SerializeField] private int _maxIngotAmountInOnventory;
    [SerializeField] private int _maxPlankAmountInOnventory;
    
    public int MaxIngotInInventory => _maxIngotAmountInOnventory - _ingotAmount;
    public int MaxPlankInInventory => _maxPlankAmountInOnventory - _plankAmount;
    
    public int MaxOreInInventory => _maxOreAmountInOnventory - _oreAmount;
    public int MaxWoodInInventory => _maxWoodAmountInOnventory - _woodAmount;

    public int OreAmount => _oreAmount;
    
    public int WoodAmount => _woodAmount;

    public event UnityAction<int> AddOreToFabric;
    public event UnityAction<int> AddWoodToFabric;
    
    public event UnityAction<int> OreAmountInventoryChanged;
    public event UnityAction<int> IngotAmountInventoryChanged;
    public event UnityAction<int> WoodAmountInventoryChanged;
    public event UnityAction<int> PlankAmountInventoryChanged;
    
    private void OnEnable()
    {
        _resourcesCreation.OreIsCollected += AddOre;
        _resourcesCreation.WoodIsCollected += AddWood;
        _fabric.TryGetOre += GetOreAmount;
        _fabric.TryGetWood += GetWoodAmount;
        _fabric.AddIngotToInventory += AddIngot;
        _fabric.AddPlankToInventory += AddPlank;
    }

    private void OnDisable()
    {
        _resourcesCreation.OreIsCollected -= AddOre;
        _resourcesCreation.WoodIsCollected -= AddWood;
        _fabric.TryGetOre -= GetOreAmount;
        _fabric.TryGetWood -= GetWoodAmount;
        _fabric.AddIngotToInventory -= AddIngot;
        _fabric.AddPlankToInventory -= AddPlank;
    }

    private void AddOre(int value)
    {
        _oreAmount += value;
        OreAmountInventoryChanged?.Invoke(_oreAmount);
    }

    private void AddWood(int value)
    {
        _woodAmount += value;
        WoodAmountInventoryChanged?.Invoke(_woodAmount);
    }

    private void AddIngot(int value)
    {
        _ingotAmount += value;
        IngotAmountInventoryChanged?.Invoke(_ingotAmount);
    }
    private void AddPlank(int value)
    {
        _plankAmount += value;
        PlankAmountInventoryChanged?.Invoke(_plankAmount);
    }

    private void GetOreAmount()
    {
        if (_oreAmount > 0 && _oreAmount <= _fabric.MaxOreAmountOnFabric)
        {
            AddOreToFabric?.Invoke(_oreAmount);
            _oreAmount = 0;
            OreAmountInventoryChanged?.Invoke(_oreAmount);
        }
        else if (_oreAmount > 0 && _oreAmount > _fabric.MaxOreAmountOnFabric)
        {
            AddOreToFabric?.Invoke(_fabric.MaxOreAmountOnFabric);
            _oreAmount -= _fabric.MaxOreAmountOnFabric;
            OreAmountInventoryChanged?.Invoke(_oreAmount);
        }
    }
    private void GetWoodAmount()
    {
        if (_woodAmount > 0 && _woodAmount <= _fabric.MaxWoodAmountOnFabric)
        {
            AddWoodToFabric?.Invoke(_woodAmount);
            _woodAmount = 0;
            WoodAmountInventoryChanged?.Invoke(_woodAmount);
        }
        else if (_woodAmount > 0 && _woodAmount > _fabric.MaxWoodAmountOnFabric)
        {
            AddWoodToFabric?.Invoke(_fabric.MaxWoodAmountOnFabric);
            _woodAmount -= _fabric.MaxWoodAmountOnFabric;
            WoodAmountInventoryChanged?.Invoke(_woodAmount);
        }
    }
    
}
