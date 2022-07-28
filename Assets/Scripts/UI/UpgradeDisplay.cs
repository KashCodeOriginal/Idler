using System;
using TMPro;
using UnityEngine;

public class UpgradeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _mineCostText;
    [SerializeField] private TMP_Text _mineLevelText;
    
    [SerializeField] private TMP_Text _woodCostText;
    [SerializeField] private TMP_Text _woodLevelText;
    
    [SerializeField] private TMP_Text _ingotCostText;
    [SerializeField] private TMP_Text _ingotLevelText;
    
    [SerializeField] private TMP_Text _plankCostText;
    [SerializeField] private TMP_Text _plankLevelText;
    
    [SerializeField] private TMP_Text _storageCostText;
    [SerializeField] private TMP_Text _storageLevelText;
    
    [SerializeField] private TMP_Text _speedCostText;
    [SerializeField] private TMP_Text _speedLevelText;
    
    [SerializeField] private TMP_Text _inventoryCostText;
    [SerializeField] private TMP_Text _inventoryLevelText;

    [SerializeField] private Upgrade _upgrade;

    private void OnEnable()
    {
        _upgrade.MineInfoChanged += ChangeMineInfo;
        _upgrade.WoodInfoChanged += ChangeWoodInfo;
        _upgrade.IngotInfoChanged += ChangeIngotInfo;
        _upgrade.PlankInfoChanged += ChangePlankInfo;
        _upgrade.StorageInfoChanged += ChangeStorageInfo;
        _upgrade.SpeedInfoChanged += ChangeSpeedInfo;
        _upgrade.InventoryInfoChanged += ChangeInventoryInfo;
    }
    private void OnDisable()
    {
        _upgrade.MineInfoChanged -= ChangeMineInfo;
        _upgrade.WoodInfoChanged -= ChangeWoodInfo;
        _upgrade.IngotInfoChanged -= ChangeIngotInfo;
        _upgrade.PlankInfoChanged -= ChangePlankInfo;
        _upgrade.StorageInfoChanged -= ChangeStorageInfo;
        _upgrade.SpeedInfoChanged -= ChangeSpeedInfo;
        _upgrade.InventoryInfoChanged -= ChangeInventoryInfo;
    }

    private void ChangeMineInfo(int value, int level)
    {
        _mineLevelText.text = "Current Level: " + level;
        _mineCostText.text = "Current Price: " + value;
    }
    private void ChangeWoodInfo(int value, int level)
    {
        _woodCostText.text = "Current Level: " + level;
        _woodLevelText.text = "Current Price: " + value;
    }
    private void ChangeIngotInfo(int value, int level)
    {
        _ingotCostText.text = "Current Level: " + level;
        _ingotLevelText.text = "Current Price: " + value;
    }
    private void ChangePlankInfo(int value, int level)
    {
        _plankCostText.text = "Current Level: " + level;
        _plankLevelText.text = "Current Price: " + value;
    }
    private void ChangeStorageInfo(int value, int level)
    {
        _storageCostText.text = "Current Level: " + level;
        _storageLevelText.text = "Current Price: " + value;
    }
    private void ChangeSpeedInfo(int value, int level)
    {
        _speedCostText.text = "Current Level: " + level;
        _speedLevelText.text = "Current Price: " + value;
    }
    private void ChangeInventoryInfo(int value, int level)
    {
        _inventoryCostText.text = "Current Level: " + level;
        _inventoryLevelText.text = "Current Price: " + value;
    }
}
