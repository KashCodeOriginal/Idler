using System;
using TMPro;
using UnityEngine;

public class UpgradeDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _mineCostText;
    [SerializeField] private TMP_Text _mineLevelText;

    [SerializeField] private Upgrade _upgrade;

    private void OnEnable()
    {
        _upgrade.MineInfoChanged += ChangeMineInfo;
    }

    private void ChangeMineInfo(int value, int level)
    {
        _mineLevelText.text = "Current Level: " + level;
        _mineCostText.text = "Current Price: " + value;
    }
}
