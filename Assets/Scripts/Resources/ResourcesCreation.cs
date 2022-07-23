using UnityEngine;
using UnityEngine.Events;

public class ResourcesCreation : MonoBehaviour
{
    [SerializeField] private float _timeBetweenOreSpawn;

    [SerializeField] private int _amountOfOre;
    
    [SerializeField] private int _maxAmountOfOre;

    [SerializeField] private float _timeBetweenWoodSpawn;
    
    [SerializeField] private int _amountOfWood;

    [SerializeField] private int _maxAmountOfWood;

    [SerializeField] private CollectResource _collectResource;

    [SerializeField] private PlayerInventory _playerInventory;
    
    public event UnityAction<int> OreAmountChanged;
    public event UnityAction<int> WoodAmountChanged;

    public event UnityAction<int> OreIsCollected;
    public event UnityAction<int> WoodIsCollected;
    
    private float _currentOreTime;
    private float _currentWoodTime;

    private void FixedUpdate()
    {
        _currentOreTime += Time.fixedDeltaTime;
        _currentWoodTime += Time.fixedDeltaTime;
        
        if (_currentOreTime >= _timeBetweenOreSpawn && _amountOfOre < _maxAmountOfOre)
        {
            _amountOfOre++;
            _currentOreTime = 0;
            OreAmountChanged?.Invoke(_amountOfOre);
        }
        if (_currentWoodTime >= _timeBetweenWoodSpawn && _amountOfWood < _maxAmountOfWood)
        {
            _amountOfWood++;
            _currentWoodTime = 0;
            WoodAmountChanged?.Invoke(_amountOfWood);
        }
        if (_amountOfOre > _maxAmountOfOre)
        {
            _amountOfOre = _maxAmountOfOre;
        }
        if (_amountOfWood > _maxAmountOfWood)
        {   
            _amountOfWood = _maxAmountOfWood;
        }
    }

    private void OnEnable()
    {
        _collectResource.OreCollected += CollectOre;
        _collectResource.WoodCollected += CollectWood;
    }
    private void OnDisable()
    {
        _collectResource.OreCollected -= CollectOre;
        _collectResource.WoodCollected -= CollectWood;
    }
    
    private void CollectOre()
    {
        _playerInventory.TryGetItemValue(ref _amountOfOre, _playerInventory.MaxOreInInventory, OreIsCollected, OreAmountChanged);
    }
    private void CollectWood()
    {
        _playerInventory.TryGetItemValue(ref _amountOfWood, _playerInventory.MaxWoodInInventory, WoodIsCollected, WoodAmountChanged);
    }
}
