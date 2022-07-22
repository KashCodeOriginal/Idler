using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fabric : MonoBehaviour
{
    [SerializeField] private FabricFill _fabricFill;
    [SerializeField] private FabricCollect _fabricCollect;
    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private int _oreAmountOnFabric;
    [SerializeField] private int _maxOreAmountOnFabric;
    
    [SerializeField] private int _woodAmountOnFabric;
    [SerializeField] private int _maxWoodAmountOnFabric;
    
    [SerializeField] private int _ironIngotAmountOnFabric;
    [SerializeField] private int _woodPlanksAmountOnFabric;

    [SerializeField] private int _maxIronIngotAmountOnFabric;
    [SerializeField] private int _maxWoodPlanksAmountOnFabric;

    [SerializeField] private float _timeBetweenIngotsSmelting;
    [SerializeField] private float _timeBetweenPlanksProcessing;
    
    private float _currentTimeBetweenIngots;
    private float _currentTimeBetweenPlanks;

    public int MaxOreAmountOnFabric => _maxOreAmountOnFabric - _oreAmountOnFabric;
    public int MaxWoodAmountOnFabric => _maxWoodAmountOnFabric - _woodAmountOnFabric;

    public event UnityAction TryGetOre;
    public event UnityAction TryGetWood;

    public event UnityAction<int> OreAmountChanged;
    public event UnityAction<int> WoodAmountChanged;
    
    public event UnityAction<int> IngotsAmountChanged;
    public event UnityAction<int> PlanksAmountChanged;

    public event UnityAction PlacingBox;
    
    private void FixedUpdate()
    {
        if (_oreAmountOnFabric > 0 && _oreAmountOnFabric <= _maxIronIngotAmountOnFabric)
        {
            _currentTimeBetweenIngots += Time.fixedDeltaTime;
            
            if (_currentTimeBetweenIngots >= _timeBetweenIngotsSmelting)
            {
                _oreAmountOnFabric--;
                _ironIngotAmountOnFabric++;
                OreAmountChanged?.Invoke(_oreAmountOnFabric);
                IngotsAmountChanged?.Invoke(_ironIngotAmountOnFabric);
                _currentTimeBetweenIngots = 0;
            }
        }

        if (_woodAmountOnFabric > 0)
        {
            _currentTimeBetweenPlanks += Time.fixedDeltaTime;

            if (_currentTimeBetweenPlanks >= _timeBetweenPlanksProcessing)
            {
                _woodAmountOnFabric--;
                _woodPlanksAmountOnFabric++;
                WoodAmountChanged?.Invoke(_woodAmountOnFabric);
                PlanksAmountChanged?.Invoke(_woodPlanksAmountOnFabric);
                _currentTimeBetweenPlanks = 0;
            }
        }
    }
    
    private void OnEnable()
    {
        _fabricFill.TryFillOreOnFabric += TryGetOreFromPlayer;
        _fabricFill.TryFillWoodOnFabric += TryGetWoodFromPlayer;
        _playerInventory.AddOreToFabric += AddOre;
        _playerInventory.AddWoodToFabric += AddWood;
        _fabricCollect.TryCollectIngotOnFabric += 
    }
    private void OnDisable()
    {
        _fabricFill.TryFillOreOnFabric -= TryGetOreFromPlayer;
        _fabricFill.TryFillWoodOnFabric -= TryGetWoodFromPlayer;
        _playerInventory.AddOreToFabric -= AddOre;
        _playerInventory.AddWoodToFabric -= AddWood;
        _fabricCollect.TryCollectIngotOnFabric -=  
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
        
    }
}
