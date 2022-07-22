using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ResourcesCreation _resourcesCreation;
    
    [SerializeField] private Fabric _fabric;

    [SerializeField] private int _oreAmount;
    [SerializeField] private int _woodAmount;
    
    [SerializeField] private int _maxOreAmmountInOnventory;
    [SerializeField] private int _maxWoodAmmountInOnventory;
    
    public int MaxOreInInventory => _maxOreAmmountInOnventory - _oreAmount;
    public int MaxWoodInInventory => _maxWoodAmmountInOnventory - _woodAmount;

    public int OreAmount => _oreAmount;
    
    public int WoodAmount => _woodAmount;

    public event UnityAction<int> AddOreToFabric;
    public event UnityAction<int> AddWoodToFabric;

    private void Start()
    {
        //Load();
    }
    private void OnEnable()
    {
        _resourcesCreation.OreIsCollected += AddOre;
        _resourcesCreation.WoodIsCollected += AddWood;
        _fabric.TryGetOre += GetOreAmount;
        _fabric.TryGetWood += GetWoodAmount;
    }

    private void OnDisable()
    {
        _resourcesCreation.OreIsCollected -= AddOre;
        _resourcesCreation.WoodIsCollected -= AddWood;
        _fabric.TryGetOre -= GetOreAmount;
        _fabric.TryGetWood -= GetWoodAmount;
    }

    private void AddOre(int value)
    {
        _oreAmount += value;
        Save();
    }

    private void AddWood(int value)
    {
        _woodAmount += value;
        Save();
    }

    private void GetOreAmount()
    {
        if (_oreAmount > 0 && _oreAmount <= _fabric.MaxOreAmountOnFabric)
        {
            AddOreToFabric?.Invoke(_oreAmount);
            _oreAmount = 0;
        }
        else if (_oreAmount > 0 && _oreAmount > _fabric.MaxOreAmountOnFabric)
        {
            AddOreToFabric?.Invoke(_fabric.MaxOreAmountOnFabric);
        }

        Save();
    }
    private void GetWoodAmount()
    {
        if (_woodAmount > 0 && _woodAmount <= _fabric.MaxWoodAmountOnFabric)
        {
            AddWoodToFabric?.Invoke(_woodAmount);
            _woodAmount = 0;
        }
        else if (_woodAmount > 0 && _woodAmount > _fabric.MaxWoodAmountOnFabric)
        {
            AddWoodToFabric?.Invoke(_fabric.MaxWoodAmountOnFabric);
        }

        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("InventoryOreAmount", _oreAmount);
        PlayerPrefs.SetInt("InventoryWoodAmount", _woodAmount);
    }

    private void Load()
    {
        _oreAmount = PlayerPrefs.GetInt("InventoryOreAmount");
        _woodAmount = PlayerPrefs.GetInt("InventoryWoodAmount");
    }
}
