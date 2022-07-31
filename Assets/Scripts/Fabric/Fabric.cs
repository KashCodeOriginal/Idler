using UnityEngine;
using UnityEngine.Events;

public class Fabric : MonoBehaviour
{
    [SerializeField] private FabricFill _fabricFill;
    [SerializeField] private FabricCollect _fabricCollect;
    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private Upgrade _upgrade;

    [SerializeField] private int _oreAmountOnFabric;
    [SerializeField] private int _maxOreAmountOnFabric = 10;
    
    [SerializeField] private int _woodAmountOnFabric;
    [SerializeField] private int _maxWoodAmountOnFabric = 10;
    
    [SerializeField] private int _ironIngotAmountOnFabric;
    [SerializeField] private int _woodPlanksAmountOnFabric;

    [SerializeField] private int _maxIronIngotAmountOnFabric = 10;
    [SerializeField] private int _maxWoodPlanksAmountOnFabric = 10;

    [SerializeField] private float _timeBetweenIngotsSmelting = 5f;
    [SerializeField] private float _timeBetweenPlanksProcessing = 5f;
    
    private float _currentTimeBetweenIngots;
    private float _currentTimeBetweenPlanks;

    public int MaxOreAmountOnFabric => _maxOreAmountOnFabric - _oreAmountOnFabric;
    public int MaxWoodAmountOnFabric => _maxWoodAmountOnFabric - _woodAmountOnFabric;

    public event UnityAction TryGetOre;
    public event UnityAction TryGetWood;

    public event UnityAction<int> AddIngotToInventory;
    public event UnityAction<int> AddPlankToInventory;

    public event UnityAction<int> OreAmountChanged;
    public event UnityAction<int> WoodAmountChanged;
    
    public event UnityAction<int> IngotsAmountChanged;
    public event UnityAction<int> PlanksAmountChanged;

    public event UnityAction PlacingBox;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (_oreAmountOnFabric > 0 && _oreAmountOnFabric <= _maxOreAmountOnFabric && _ironIngotAmountOnFabric < _maxIronIngotAmountOnFabric)
        {
            _currentTimeBetweenIngots += Time.fixedDeltaTime;
            
            ProcessItem(ref _currentTimeBetweenIngots, _timeBetweenIngotsSmelting, ref _oreAmountOnFabric, ref _ironIngotAmountOnFabric, OreAmountChanged, IngotsAmountChanged);
        }
        if (_woodAmountOnFabric > 0 && _woodAmountOnFabric <= _maxWoodAmountOnFabric && _woodPlanksAmountOnFabric < _maxWoodPlanksAmountOnFabric)
        {
            _currentTimeBetweenPlanks += Time.fixedDeltaTime;
            
            ProcessItem(ref _currentTimeBetweenPlanks, _timeBetweenPlanksProcessing, ref _woodAmountOnFabric, ref _woodPlanksAmountOnFabric, WoodAmountChanged, PlanksAmountChanged);
        }
    }
    
    private void OnEnable()
    {
        _fabricFill.TryFillOreOnFabric += TryGetOreFromPlayer;
        _fabricFill.TryFillWoodOnFabric += TryGetWoodFromPlayer;
        
        _playerInventory.AddOreToFabric += AddOre;
        _playerInventory.AddWoodToFabric += AddWood;
        
        _fabricCollect.TryCollectIngotOnFabric += TryCollectIngotFromFabric;
        _fabricCollect.TryCollectPlankOnFabric += TryCollectPlankFromFabric;

        _upgrade.UpgradeOreFabric += UpgradeOreFabricSpeed;
        _upgrade.UpgradeWoodFabric += UpgradeWoodFabricSpeed;
    }
    private void OnDisable()
    {
        _fabricFill.TryFillOreOnFabric -= TryGetOreFromPlayer;
        _fabricFill.TryFillWoodOnFabric -= TryGetWoodFromPlayer;
        
        _playerInventory.AddOreToFabric -= AddOre;
        _playerInventory.AddWoodToFabric -= AddWood;
        
        _fabricCollect.TryCollectIngotOnFabric -= TryCollectIngotFromFabric;
        _fabricCollect.TryCollectPlankOnFabric -= TryCollectPlankFromFabric;
        
        _upgrade.UpgradeOreFabric -= UpgradeOreFabricSpeed;
        _upgrade.UpgradeWoodFabric -= UpgradeWoodFabricSpeed;
    }

    private void TryGetOreFromPlayer()
    {
        TryGetOre?.Invoke();
    }
    private void TryGetWoodFromPlayer()
    {
        TryGetWood?.Invoke();
    }

    private void AddOre(int value)
    {
        _oreAmountOnFabric += value;
        OreAmountChanged?.Invoke(_oreAmountOnFabric);
        PlacingBox?.Invoke();
    }
    private void AddWood(int value)
    {
        _woodAmountOnFabric += value;
        WoodAmountChanged?.Invoke(_woodAmountOnFabric);
        PlacingBox?.Invoke();
    }

    private void TryCollectIngotFromFabric()
    {
        _playerInventory.TryGetItemValue(ref _ironIngotAmountOnFabric, _playerInventory.MaxIngotInInventory, AddIngotToInventory, IngotsAmountChanged);
    }
    private void TryCollectPlankFromFabric()
    {
        _playerInventory.TryGetItemValue(ref _woodPlanksAmountOnFabric, _playerInventory.MaxPlankInInventory, AddPlankToInventory, PlanksAmountChanged);
    }

    private void ProcessItem(ref float currentTime, float timeBetweenProcessing,ref int inputItem,ref int outputItem, UnityAction<int> inputItemAmountChange,UnityAction<int> outputItemAmountChange)
    {
        if (currentTime >= timeBetweenProcessing)
        {
            inputItem--;
            outputItem++;
            inputItemAmountChange?.Invoke(inputItem);
            outputItemAmountChange?.Invoke(outputItem);
            currentTime = 0;
        }
    }

    private void UpgradeOreFabricSpeed()
    {
        if (_timeBetweenIngotsSmelting <= 1)
        {
            _timeBetweenIngotsSmelting -= 0.1f;
        }
        else if (_timeBetweenIngotsSmelting <= 0.3)
        {
            _timeBetweenIngotsSmelting -= 0.05f;
        }
        else
        {
            _timeBetweenIngotsSmelting -= 1;
        }

        _maxOreAmountOnFabric += 5;
        _maxIronIngotAmountOnFabric += 5;
    }
    private void UpgradeWoodFabricSpeed()
    {
        if (_timeBetweenPlanksProcessing <= 1)
        {
            _timeBetweenPlanksProcessing -= 0.1f;
        }
        else if (_timeBetweenPlanksProcessing <= 0.3)
        {
            _timeBetweenPlanksProcessing -= 0.05f;
        }
        else
        {
            _timeBetweenPlanksProcessing -= 1;
        }
        
        _maxWoodAmountOnFabric += 5;
        _maxWoodPlanksAmountOnFabric += 5;
    }
}
