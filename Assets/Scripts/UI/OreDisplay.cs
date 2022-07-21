using System;
using TMPro;
using UnityEngine;

public class OreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private MineResourcesCreation _mineResourcesCreation;

    private void OnEnable()
    {
        _mineResourcesCreation.OreAmmountChanged += ChangeValue;
    }
    private void OnDisable()
    {
        _mineResourcesCreation.OreAmmountChanged -= ChangeValue;
    }

    private void ChangeValue(int value)
    {
        _valueText.text = value.ToString();
    }
}
