using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private List<GameObject> _items;

    [SerializeField] private StorageSwitcher _storageSwitcher;

    [SerializeField] private List<int> _itemsAmount;

    private void OnEnable()
    {
        _storageSwitcher.ItemChanged += ShowInfo;
    }
    private void OnDisable()
    {
        _storageSwitcher.ItemChanged -= ShowInfo;
    }

    private void ShowInfo(int id)
    {
        _items[id].GetComponentInChildren<TextMeshProUGUI>().text = _itemsAmount[id].ToString();
    }
}
