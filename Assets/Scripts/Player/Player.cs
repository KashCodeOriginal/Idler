using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;
    
    [SerializeField] private Fabric _fabric;

    [SerializeField] private Storage _storage;

    [SerializeField] private SellToMarket _sellToMarket;

    [SerializeField] private int _coins;

    [SerializeField] private Upgrade _upgrade;
    
    public event UnityAction<int> ChangeCoinsAmount;

    public event UnityAction MineIsUpgraded;
    public event UnityAction WoodIsUpgraded;
    public event UnityAction OreFabricIsUpgraded;
    public event UnityAction WoodFabricIsUpgraded;
    public event UnityAction PlayerInventoryIsUpgraded;
    public event UnityAction PlayerSpeedIsUpgraded;
    public event UnityAction StorageIsUpgraded;

    private void Start()
    {
        Application.targetFrameRate = 60;
        Load();
        ChangeCoinsAmount?.Invoke(_coins);
    }

    private void PlayerRun(bool isPlayerRunning)
    {
        _animator.SetBool("IsRunning", isPlayerRunning);
    }
    private void PlayerIdleingWithBoxes(bool isPlayerIdleingWithBoxes)
    {
        _animator.SetBool("IsCarrying", isPlayerIdleingWithBoxes);
    }
    private void PlayerRunningWithBoxes(bool isPlayerRunningWithBoxes)
    {
        _animator.SetBool("IsCarryingAndRunning", isPlayerRunningWithBoxes);
    }
    private void PlayerPlacingBox()
    {
        _animator.SetTrigger("Placing");
    }

    private void OnEnable()
    {
        _playerMovement.PlayerIsRunning += PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources += PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources += PlayerRunningWithBoxes;
        _fabric.PlacingBox += PlayerPlacingBox;
        _storage.PlacingBox += PlayerPlacingBox;
        
        _sellToMarket.CoinsAmountChanged += AddCoins;

        _sellToMarket.PlacingBox += PlayerPlacingBox;

        _upgrade.TryUpgradeMine += TryBuyMineUpgrade;
        _upgrade.TryUpgradeWood += TryBuyWoodUpgrade;
        _upgrade.TryUpgradeOreFabric += TryBuyOreFabricUpgrade;
        _upgrade.TryUpgradeWoodFabric += TryBuyWoodFabricUpgrade;
        _upgrade.TryUpgradePlayerInventory += TryBuyPlayerInventoryUpgrade;
        _upgrade.TryUpgradePlayerSpeed += TryBuyPlayerSpeedUpgrade;
        _upgrade.TryUpgradeStorage += TryBuyStorageUpgrade;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerIsRunning -= PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources -= PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources -= PlayerRunningWithBoxes;
        _fabric.PlacingBox -= PlayerPlacingBox;
        _storage.PlacingBox -= PlayerPlacingBox;
        
        _sellToMarket.CoinsAmountChanged -= AddCoins;
        
        _sellToMarket.PlacingBox -= PlayerPlacingBox;
        
        _upgrade.TryUpgradeMine -= TryBuyMineUpgrade;
        _upgrade.TryUpgradeWood -= TryBuyWoodUpgrade;
        _upgrade.TryUpgradeOreFabric -= TryBuyOreFabricUpgrade;
        _upgrade.TryUpgradeWoodFabric -= TryBuyWoodFabricUpgrade;
        _upgrade.TryUpgradePlayerInventory -= TryBuyPlayerInventoryUpgrade;
        _upgrade.TryUpgradePlayerSpeed -= TryBuyPlayerSpeedUpgrade;
        _upgrade.TryUpgradeStorage -= TryBuyStorageUpgrade;
    }
    
    private void AddCoins(int value)
    {
        _coins += value;
        ChangeCoinsAmount?.Invoke(_coins);
        Save();
    }

    private void TryBuyMineUpgrade(int value)
    {
        TryBuyUpgrade(value, MineIsUpgraded);
    }
    private void TryBuyWoodUpgrade(int value)
    {
        TryBuyUpgrade(value, WoodIsUpgraded);
    }
    private void TryBuyOreFabricUpgrade(int value)
    {
        TryBuyUpgrade(value, OreFabricIsUpgraded);
    }
    private void TryBuyWoodFabricUpgrade(int value)
    {
        TryBuyUpgrade(value, WoodFabricIsUpgraded);
    }
    private void TryBuyPlayerInventoryUpgrade(int value)
    {
        TryBuyUpgrade(value, PlayerInventoryIsUpgraded);
    }
    private void TryBuyPlayerSpeedUpgrade(int value)
    {
        TryBuyUpgrade(value, PlayerSpeedIsUpgraded);
    }
    private void TryBuyStorageUpgrade(int value)
    {
        TryBuyUpgrade(value, StorageIsUpgraded);
    }

    private void TryBuyUpgrade(int value, UnityAction itemIsUpgraded)
    {
        if (_coins >= value)
        {
            _coins -= value;
            ChangeCoinsAmount?.Invoke(_coins);
            itemIsUpgraded?.Invoke();
            Save();
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Coins", _coins);
    }
    private void Load()
    {
        _coins = PlayerPrefs.GetInt("Coins");
    }
}
