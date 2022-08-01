using System;
using UnityEngine;
using UnityEngine.Events;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private int _priceMultiplyer;
    
    public event UnityAction<int> TryUpgradeMine;
    public event UnityAction<int> TryUpgradeWood;
    public event UnityAction<int> TryUpgradeOreFabric;
    public event UnityAction<int> TryUpgradeWoodFabric;
    public event UnityAction<int> TryUpgradePlayerInventory;
    public event UnityAction<int> TryUpgradePlayerSpeed;
    public event UnityAction<int> TryUpgradeStorage;
    
    public event UnityAction UpgradeMine;
    public event UnityAction UpgradeWood;
    public event UnityAction UpgradeOreFabric;
    public event UnityAction UpgradeWoodFabric;
    public event UnityAction UpgradePlayerInventory;
    public event UnityAction UpgradePlayerSpeed;
    public event UnityAction UpgradeStorage;
    
    public event UnityAction<int, int> MineInfoChanged;
    public event UnityAction<int, int> WoodInfoChanged;
    public event UnityAction<int, int> IngotInfoChanged;
    public event UnityAction<int, int> PlankInfoChanged;
    public event UnityAction<int, int> StorageInfoChanged;
    public event UnityAction<int, int> SpeedInfoChanged;
    public event UnityAction<int, int> InventoryInfoChanged;

    [SerializeField] private int _mineUpgradePrice;
    [SerializeField] private int _woodUpgradePrice;
    [SerializeField] private int _oreFabricUpgradePrice;
    [SerializeField] private int _woodFabricUpgradePrice;
    [SerializeField] private int _playerInventoryUpgradePrice;
    [SerializeField] private int _playerSpeedUpgradePrice;
    [SerializeField] private int _storageUpgradePrice;
    [Space(5)]
    [SerializeField] private int _mineLevel;
    [SerializeField] private int _woodLevel;
    [SerializeField] private int _oreFabricLevel;
    [SerializeField] private int _woodFabricLevel;
    [SerializeField] private int _playerInventoryLevel;
    [SerializeField] private int _playerSpeedLevel;
    [SerializeField] private int _storageLevel;

    public void OnMineUpgradeClick()
    {
        TryUpgradeMine?.Invoke(_mineUpgradePrice);
    }
    public void OnWoodUpgradeClick()
    {
        TryUpgradeWood?.Invoke(_woodUpgradePrice);
    }
    public void OnOreFabricUpgradeClick()
    {
        TryUpgradeOreFabric?.Invoke(_oreFabricUpgradePrice);
    }
    public void OnWoodFabricUpgradeClick()
    {
        TryUpgradeWoodFabric?.Invoke(_woodFabricUpgradePrice);
    }
    public void OnPlayerInventoryUpgradeClick()
    {
        TryUpgradePlayerInventory?.Invoke(_playerInventoryUpgradePrice);
    }
    public void OnPlayerSpeedUpgradeClick()
    {
        TryUpgradePlayerSpeed?.Invoke(_playerSpeedUpgradePrice);
    }
    public void OnStorageUpgradeClick()
    {
        TryUpgradeStorage?.Invoke(_storageUpgradePrice);
    }
    
    private void Start()
    {
        Load();
        MineInfoChanged?.Invoke(_mineUpgradePrice, _mineLevel);
        WoodInfoChanged?.Invoke(_woodUpgradePrice, _woodLevel);
        IngotInfoChanged?.Invoke(_oreFabricUpgradePrice, _oreFabricLevel);
        PlankInfoChanged?.Invoke(_woodFabricUpgradePrice, _woodFabricLevel);
        InventoryInfoChanged?.Invoke(_playerInventoryUpgradePrice, _playerInventoryLevel);
        SpeedInfoChanged?.Invoke(_playerSpeedUpgradePrice, _playerSpeedLevel);
        StorageInfoChanged?.Invoke(_storageUpgradePrice, _storageLevel);
    }

    private void OnEnable()
    {
        _player.MineIsUpgraded += MineUpgrade;
        _player.WoodIsUpgraded += WoodUpgrade;
        _player.OreFabricIsUpgraded += OreFabricUpgrade;
        _player.WoodFabricIsUpgraded += WoodFabricUpgrade;
        _player.PlayerInventoryIsUpgraded += PlayerInventoryUpgrade;
        _player.PlayerSpeedIsUpgraded += PlayerSpeedUpgrade;
        _player.StorageIsUpgraded += StorageUpgrade;
    }
    private void OnDisable()
    {
        _player.MineIsUpgraded -= MineUpgrade;
        _player.WoodIsUpgraded -= WoodUpgrade;
        _player.OreFabricIsUpgraded -= OreFabricUpgrade;
        _player.WoodFabricIsUpgraded -= WoodFabricUpgrade;
        _player.PlayerInventoryIsUpgraded -= PlayerInventoryUpgrade;
        _player.PlayerSpeedIsUpgraded -= PlayerSpeedUpgrade;
        _player.StorageIsUpgraded -= StorageUpgrade;
    }

    private void MineUpgrade()
    {
        _mineUpgradePrice += _priceMultiplyer * _mineLevel;
        _mineLevel += 1;
        UpgradeMine?.Invoke();
        MineInfoChanged?.Invoke(_mineUpgradePrice, _mineLevel);
        Save();
    }
    private void WoodUpgrade()
    {
        _woodUpgradePrice += _priceMultiplyer * _woodLevel;
        _woodLevel += 1;
        UpgradeWood?.Invoke();
        WoodInfoChanged(_woodUpgradePrice, _woodLevel);
        Save();
    }
    private void OreFabricUpgrade()
    {
        _oreFabricUpgradePrice += _priceMultiplyer * _oreFabricLevel;
        _oreFabricLevel += 1;
        UpgradeOreFabric?.Invoke();
        IngotInfoChanged(_oreFabricUpgradePrice, _oreFabricLevel);
        Save();
    }
    private void WoodFabricUpgrade()
    {
        _woodFabricUpgradePrice += _priceMultiplyer * _woodFabricLevel;
        _woodFabricLevel += 1;
        UpgradeWoodFabric?.Invoke();
        PlankInfoChanged(_woodFabricUpgradePrice, _woodFabricLevel);
        Save();
    }
    private void PlayerInventoryUpgrade()
    {
        _playerInventoryUpgradePrice += _priceMultiplyer * _playerInventoryLevel;
        _playerInventoryLevel += 1;
        UpgradePlayerInventory?.Invoke();
        InventoryInfoChanged(_playerInventoryUpgradePrice, _playerInventoryLevel);
        Save();
    }
    private void PlayerSpeedUpgrade()
    {
        _playerSpeedUpgradePrice += _priceMultiplyer * _playerSpeedLevel;
        _playerSpeedLevel += 1;
        UpgradePlayerSpeed?.Invoke();
        SpeedInfoChanged(_playerSpeedUpgradePrice, _playerSpeedLevel);
        Save();
    }
    private void StorageUpgrade()
    {
        _storageUpgradePrice += _priceMultiplyer * _storageLevel;
        _storageLevel += 1;
        UpgradeStorage?.Invoke();
        StorageInfoChanged(_storageUpgradePrice, _storageLevel);
        Save();
    }
    
    private void Save()
    {
        PlayerPrefs.SetInt("MinePrice", _mineUpgradePrice);
        PlayerPrefs.SetInt("OrePrice", _woodUpgradePrice);
        PlayerPrefs.SetInt("MineFabricPrice", _oreFabricUpgradePrice);
        PlayerPrefs.SetInt("WoodFabricPrice", _woodFabricUpgradePrice);
        PlayerPrefs.SetInt("InventoryPrice", _playerInventoryUpgradePrice);
        PlayerPrefs.SetInt("SpeedPrice", _playerSpeedUpgradePrice);
        PlayerPrefs.SetInt("StoragePrice", _storageUpgradePrice);
        PlayerPrefs.SetInt("MineLevel", _mineLevel);
        PlayerPrefs.SetInt("WoodLevel", _woodLevel);
        PlayerPrefs.SetInt("MineFabricLevel", _oreFabricLevel);
        PlayerPrefs.SetInt("WoodFabricLevel", _woodFabricLevel);
        PlayerPrefs.SetInt("InventoryLevel", _playerInventoryLevel);
        PlayerPrefs.SetInt("SpeedLevel", _playerSpeedLevel);
        PlayerPrefs.SetInt("StorageLevel", _storageLevel);
    }

    private void Load()
    {
        _mineUpgradePrice = PlayerPrefs.GetInt("MinePrice", 15);
        _woodUpgradePrice = PlayerPrefs.GetInt("OrePrice", 10);
        _oreFabricUpgradePrice = PlayerPrefs.GetInt("MineFabricPrice", 30);
        _woodFabricUpgradePrice = PlayerPrefs.GetInt("WoodFabricPrice", 25);
        _playerInventoryUpgradePrice = PlayerPrefs.GetInt("InventoryPrice", 50);
        _playerSpeedUpgradePrice = PlayerPrefs.GetInt("SpeedPrice", 50);
        _storageUpgradePrice = PlayerPrefs.GetInt("StoragePrice", 100);
        _mineLevel = PlayerPrefs.GetInt("MineLevel", 1);
        _woodLevel = PlayerPrefs.GetInt("WoodLevel", 1);
        _oreFabricLevel = PlayerPrefs.GetInt("MineFabricLevel", 1);
        _woodFabricLevel = PlayerPrefs.GetInt("WoodFabricLevel", 1);
        _playerInventoryLevel = PlayerPrefs.GetInt("InventoryLevel", 1);
        _playerSpeedLevel = PlayerPrefs.GetInt("SpeedLevel", 1);
        _storageLevel = PlayerPrefs.GetInt("StorageLevel", 1);
    }
}
