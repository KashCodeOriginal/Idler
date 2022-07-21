using System;
using UnityEngine;

public class ResourcesCreation : MonoBehaviour
{
    [SerializeField] private float _timeBetweenOreSpawn;

    [SerializeField] private int _amountOfOre;
    
    [SerializeField] private int _maxAmountOfOre;

    [SerializeField] private float _timeBetweenWoodSpawn;
    
    [SerializeField] private int _amountOfWood;

    [SerializeField] private int _maxAmountOfWood;

    [SerializeField] private CollectResource _collectResource;
    
    public event Action<int> OreAmountChanged;
    public event Action<int> WoodAmountChanged;

    public event Action<int> OreIsCollected;
    public event Action<int> WoodIsCollected;
    
    private float _currentOreTime;
    private float _currentWoodTime;

    private void Start()
    {
        //Load();
    }

    private void FixedUpdate()
    {
        _currentOreTime += Time.fixedDeltaTime;
        _currentWoodTime += Time.fixedDeltaTime;
        
        if (_currentOreTime >= _timeBetweenOreSpawn && _amountOfOre < _maxAmountOfOre)
        {
            _amountOfOre++;
            _currentOreTime = 0;
            OreAmountChanged?.Invoke(_amountOfOre);
            Save();
        }
        if (_currentWoodTime >= _timeBetweenWoodSpawn && _amountOfWood < _maxAmountOfWood)
        {
            _amountOfWood++;
            _currentWoodTime = 0;
            WoodAmountChanged?.Invoke(_amountOfWood);
            Save();
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

    private void Save()
    {
        PlayerPrefs.SetInt("OreAmount", _amountOfOre);
        PlayerPrefs.SetInt("WoodAmount", _amountOfWood);
    }
    private void Load()
    {
        _amountOfOre = PlayerPrefs.GetInt("OreAmount");
        _amountOfWood = PlayerPrefs.GetInt("WoodAmount");
    }

    private void CollectOre()
    {
        if (_amountOfOre > 0)
        {
            OreIsCollected?.Invoke(_amountOfOre);
            OreAmountChanged?.Invoke(_amountOfOre);
            _amountOfOre = 0;
        }
    }
    private void CollectWood()
    {
        if (_amountOfWood > 0)
        {
            WoodIsCollected?.Invoke(_amountOfWood);
            WoodAmountChanged?.Invoke(_amountOfWood);
            _amountOfWood = 0;
        }
    }
}
