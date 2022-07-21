using System;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _oreValueText;
    [SerializeField] private TMP_Text _woodValueText;

    [SerializeField] private ResourcesCreation resourcesCreation;

    private void OnEnable()
    {
        resourcesCreation.OreAmountChanged += ChangeOreValue;
        resourcesCreation.WoodAmountChanged += ChangeWoodValue;
    }
    private void OnDisable()
    {
        resourcesCreation.OreAmountChanged -= ChangeOreValue;
        resourcesCreation.WoodAmountChanged -= ChangeWoodValue;
    }

    private void ChangeOreValue(int value)
    {
        _oreValueText.text = value.ToString();
    }
    private void ChangeWoodValue(int value)
    {
        _woodValueText.text = value.ToString();
    }
}
