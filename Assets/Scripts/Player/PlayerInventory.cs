using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ResourcesCreation _resourcesCreation;
    
    [SerializeField] private Fabric _fabric;

    [SerializeField] private StorageFill _storageFill;

    [SerializeField] private Storage _storage;

    [SerializeField] private SellToMarket _sellToMarket;

    [SerializeField] private Upgrade _upgrade;

    [SerializeField] private int _oreAmount;
    [SerializeField] private int _woodAmount;
    
    [SerializeField] private int _maxOreAmountInInventory;
    [SerializeField] private int _maxWoodAmountInInventory;
    
    [SerializeField] private int _ingotAmount;
    [SerializeField] private int _plankAmount;
    
    [SerializeField] private int _maxIngotAmountInInventory;
    [SerializeField] private int _maxPlankAmountInInventory;
    
    public int MaxIngotInInventory => _maxIngotAmountInInventory - _ingotAmount;
    public int MaxPlankInInventory => _maxPlankAmountInInventory - _plankAmount;
    
    public int MaxOreInInventory => _maxOreAmountInInventory - _oreAmount;
    public int MaxWoodInInventory => _maxWoodAmountInInventory - _woodAmount;

    public int OreAmount => _oreAmount;
    
    public int WoodAmount => _woodAmount;
    
    public int IngotAmount => _ingotAmount;
    
    public int PlankAmount => _plankAmount;

    public event UnityAction<int> AddOreToFabric;
    public event UnityAction<int> AddWoodToFabric;
    
    public event UnityAction<int> AddOreToStorage;
    public event UnityAction<int> AddWoodToStorage;
    public event UnityAction<int> AddIngotToStorage;
    public event UnityAction<int> AddPlankToStorage;
    
    public event UnityAction<int> OreAmountInventoryChanged;
    public event UnityAction<int> IngotAmountInventoryChanged;
    public event UnityAction<int> WoodAmountInventoryChanged;
    public event UnityAction<int> PlankAmountInventoryChanged;

    public event UnityAction<int> SellOre;
    public event UnityAction<int> SellWood;
    public event UnityAction<int> SellIngot;
    public event UnityAction<int> SellPlank;

    private void Start()
    {
        Load();
        OreAmountInventoryChanged?.Invoke(_oreAmount);
        WoodAmountInventoryChanged?.Invoke(_woodAmount);
        IngotAmountInventoryChanged?.Invoke(_ingotAmount);
        PlankAmountInventoryChanged?.Invoke(_plankAmount);
    }
    
    private void OnEnable()
    {
        _resourcesCreation.OreIsCollected += AddOre;
        _resourcesCreation.WoodIsCollected += AddWood;
        
        _fabric.TryGetOre += GetOreAmountForFabric;
        _fabric.TryGetWood += GetWoodAmountForFabric;
        _fabric.AddIngotToInventory += AddIngot;
        _fabric.AddPlankToInventory += AddPlank;
        
        _storageFill.TryGetOreInventoryValue += GetOreAmountForStorage;
        _storageFill.TryGetWoodInventoryValue += GetWoodAmountForStorage;
        _storageFill.TryGetIngotInventoryValue += GetIngotAmountForStorage;
        _storageFill.TryGetPlankInventoryValue += GetPlankAmountForStorage;

        _storage.AddOreToInventory += AddOre;
        _storage.AddWoodToInventory += AddWood;
        _storage.AddIngotToInventory += AddIngot;
        _storage.AddPlankToInventory += AddPlank;

        _sellToMarket.GetOreValueInInventory += TrySellOre;
        _sellToMarket.GetWoodValueInInventory += TrySellWood;
        _sellToMarket.GetIngotValueInInventory += TrySellIngot;
        _sellToMarket.GetPlankValueInInventory += TrySellPlank;

        _upgrade.UpgradePlayerInventory += UpgradePlayerInventory;
    }

    private void OnDisable()
    {
        _resourcesCreation.OreIsCollected -= AddOre;
        _resourcesCreation.WoodIsCollected -= AddWood;
        
        _fabric.TryGetOre -= GetOreAmountForFabric;
        _fabric.TryGetWood -= GetWoodAmountForFabric;
        _fabric.AddIngotToInventory -= AddIngot;
        _fabric.AddPlankToInventory -= AddPlank;
        
        _storageFill.TryGetOreInventoryValue -= GetOreAmountForStorage;
        _storageFill.TryGetWoodInventoryValue -= GetWoodAmountForStorage;
        _storageFill.TryGetIngotInventoryValue -= GetIngotAmountForStorage;
        _storageFill.TryGetPlankInventoryValue -= GetPlankAmountForStorage;
        
        _storage.AddOreToInventory -= AddOre;
        _storage.AddWoodToInventory -= AddWood;
        _storage.AddIngotToInventory -= AddIngot;
        _storage.AddPlankToInventory -= AddPlank;

        _sellToMarket.GetOreValueInInventory -= TrySellOre;
        _sellToMarket.GetWoodValueInInventory -= TrySellWood;
        _sellToMarket.GetIngotValueInInventory -= TrySellIngot;
        _sellToMarket.GetPlankValueInInventory -= TrySellPlank;
        
        _upgrade.UpgradePlayerInventory -= UpgradePlayerInventory;
    }

    private void AddOre(int value)
    {
        _oreAmount += value;
        OreAmountInventoryChanged?.Invoke(_oreAmount);
        Save();
    }

    private void AddWood(int value)
    {
        _woodAmount += value;
        WoodAmountInventoryChanged?.Invoke(_woodAmount);
        Save();
    }

    private void AddIngot(int value)
    {
        _ingotAmount += value;
        IngotAmountInventoryChanged?.Invoke(_ingotAmount);
        Save();
    }
    private void AddPlank(int value)
    {
        _plankAmount += value;
        PlankAmountInventoryChanged?.Invoke(_plankAmount);
        Save();
    }

    private void TrySellOre()
    {
        if (_oreAmount > 0)
        {
            SellOre?.Invoke(_oreAmount);
            _oreAmount = 0;
            OreAmountInventoryChanged?.Invoke(_oreAmount);
            Save();
        }
    }
    private void TrySellWood()
    {
        if (_woodAmount > 0)
        {
            SellWood?.Invoke(_woodAmount);
            _woodAmount = 0;
            WoodAmountInventoryChanged?.Invoke(_woodAmount);
            Save();
        }
    }
    private void TrySellIngot()
    {
        if (_ingotAmount > 0)
        {
            SellIngot?.Invoke(_ingotAmount);
            _ingotAmount = 0;
            IngotAmountInventoryChanged?.Invoke(_ingotAmount);
            Save();
        }
    }
    private void TrySellPlank()
    {
        if (_plankAmount > 0)
        {
            SellPlank?.Invoke(_plankAmount);
            _plankAmount = 0;
            PlankAmountInventoryChanged?.Invoke(_plankAmount);
            Save();
        }
    }

    private void GetOreAmountForFabric()
    {
        TryGetItemValue(ref _oreAmount, _fabric.MaxOreAmountOnFabric, AddOreToFabric, OreAmountInventoryChanged);
        Save();
    }
    private void GetWoodAmountForFabric()
    {
        TryGetItemValue(ref _woodAmount, _fabric.MaxWoodAmountOnFabric, AddWoodToFabric, WoodAmountInventoryChanged);
        Save();
    }

    private void GetOreAmountForStorage(int maxAmountInStorage, int value)
    {
        if (value == -1)
        {
            TryGetItemValue(ref _oreAmount, maxAmountInStorage, AddOreToStorage, OreAmountInventoryChanged);
        }
        else
        {
            TryGetItemValue(ref _oreAmount,value, maxAmountInStorage, AddOreToStorage, OreAmountInventoryChanged);
        }
        Save();
    }
    private void GetWoodAmountForStorage(int maxAmountInStorage, int value)
    {
        if (value == -1)
        {
            TryGetItemValue(ref _woodAmount, maxAmountInStorage, AddWoodToStorage, WoodAmountInventoryChanged);
        }
        else
        {
            TryGetItemValue(ref _woodAmount,value, maxAmountInStorage, AddWoodToStorage, WoodAmountInventoryChanged);
        }
        Save();
    }
    private void GetIngotAmountForStorage(int maxAmountInStorage, int value)
    {
        if (value == -1)
        {
            TryGetItemValue(ref _ingotAmount, maxAmountInStorage, AddIngotToStorage, IngotAmountInventoryChanged);
        }
        else
        {
            TryGetItemValue(ref _ingotAmount,value, maxAmountInStorage, AddIngotToStorage, IngotAmountInventoryChanged);
        }
        Save();
    }
    private void GetPlankAmountForStorage(int maxAmountInStorage, int value)
    {
        if (value == -1)
        {
            TryGetItemValue(ref _plankAmount, maxAmountInStorage, AddPlankToStorage, PlankAmountInventoryChanged);
        }
        else
        {
            TryGetItemValue(ref _plankAmount,value, maxAmountInStorage, AddPlankToStorage, PlankAmountInventoryChanged);
        }
        Save();
    }
    public void TryGetItemValue(ref int itemAmount,int maxAmount, UnityAction<int> addItem, UnityAction<int> itemValueChanged)
    {
        if (itemAmount > 0 && itemAmount <= maxAmount)
        {
            addItem?.Invoke(itemAmount);
            itemAmount = 0;
            itemValueChanged?.Invoke(itemAmount);
        }
        else if (itemAmount > 0 && itemAmount > maxAmount)
        {
            itemAmount -= maxAmount;
            addItem?.Invoke(maxAmount);
            itemValueChanged?.Invoke(itemAmount);
        }
    }

    public void TryGetItemValue(ref int itemAmount,int currentValueAmount, int maxAmount, UnityAction<int> addItem, UnityAction<int> itemValueChanged)
    {
        if (itemAmount > 0 && currentValueAmount <= maxAmount && itemAmount - currentValueAmount  >= 0)
        {
            itemAmount -= currentValueAmount;
            addItem?.Invoke(currentValueAmount);
            itemValueChanged?.Invoke(itemAmount);
        }
        else if (itemAmount > 0 && currentValueAmount >= maxAmount)
        {
            itemAmount -= maxAmount;
            addItem?.Invoke(maxAmount);
            itemValueChanged?.Invoke(itemAmount);
        }
    }

    private void UpgradePlayerInventory()
    {
        _maxOreAmountInInventory += 10;
        _maxWoodAmountInInventory += 10;
        _maxIngotAmountInInventory += 10;
        _maxPlankAmountInInventory += 10;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("OreInInventory", _oreAmount);
        PlayerPrefs.SetInt("WoodInInventory", _woodAmount);
        PlayerPrefs.SetInt("IngotInInventory", _ingotAmount);
        PlayerPrefs.SetInt("PlankInInventory", _plankAmount);
        PlayerPrefs.SetInt("MaxOreInInventory", _maxOreAmountInInventory);
        PlayerPrefs.SetInt("MaxWoodInInventory", _maxWoodAmountInInventory);
        PlayerPrefs.SetInt("MaxIngotInInventory", _maxIngotAmountInInventory);
        PlayerPrefs.SetInt("MaxPlankInInventory", _maxPlankAmountInInventory);
    }
    private void Load()
    {
        _oreAmount = PlayerPrefs.GetInt("OreInInventory");
        _woodAmount = PlayerPrefs.GetInt("WoodInInventory");
        _ingotAmount = PlayerPrefs.GetInt("IngotInInventory");
        _plankAmount = PlayerPrefs.GetInt("PlankInInventory");
        _maxOreAmountInInventory = PlayerPrefs.GetInt("MaxOreInInventory", 10);
        _maxWoodAmountInInventory = PlayerPrefs.GetInt("MaxWoodInInventory", 10);
        _maxIngotAmountInInventory = PlayerPrefs.GetInt("MaxIngotInInventory", 10);
        _maxPlankAmountInInventory = PlayerPrefs.GetInt("MaxPlankInInventory", 10);
    }
}
