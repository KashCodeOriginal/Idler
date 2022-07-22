using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _oreAmountInInventory;
    [SerializeField] private TMP_Text _ingotAmountInInventory;
    [SerializeField] private TMP_Text _woodAmountInInventory;
    [SerializeField] private TMP_Text _plankAmountInInventory;

    [SerializeField] private PlayerInventory _playerInventory;

    private void OnEnable()
    {
        _playerInventory.OreAmountInventoryChanged += ChangeOreAmount;
        _playerInventory.IngotAmountInventoryChanged += ChangeIngotAmount;
        _playerInventory.WoodAmountInventoryChanged += ChangeWoodAmount;
        _playerInventory.PlankAmountInventoryChanged += ChangePlankAmount;
    }
    private void OnDisable()
    {
        _playerInventory.OreAmountInventoryChanged -= ChangeOreAmount;
        _playerInventory.IngotAmountInventoryChanged -= ChangeIngotAmount;
        _playerInventory.WoodAmountInventoryChanged -= ChangeWoodAmount;
        _playerInventory.PlankAmountInventoryChanged -= ChangePlankAmount;
    }

    private void ChangeOreAmount(int value)
    {
        _oreAmountInInventory.text = value.ToString();
    }
    private void ChangeIngotAmount(int value)
    {
        _ingotAmountInInventory.text = value.ToString();
    }
    private void ChangeWoodAmount(int value)
    {
        _woodAmountInInventory.text = value.ToString();
    }
    private void ChangePlankAmount(int value)
    {
        _plankAmountInInventory.text = value.ToString();
    }
}
