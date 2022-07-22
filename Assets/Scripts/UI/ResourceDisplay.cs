using System;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _oreValueText;
    [SerializeField] private TMP_Text _woodValueText;
    
    [SerializeField] private TMP_Text _oreOnFabricValueText;
    [SerializeField] private TMP_Text _woodOnFabricValueText;

    [SerializeField] private ResourcesCreation resourcesCreation;
    [SerializeField] private Fabric _fabric;

    private void OnEnable()
    {
        resourcesCreation.OreAmountChanged += ChangeOreValue;
        resourcesCreation.WoodAmountChanged += ChangeWoodValue;
        _fabric.OreAmountChanged += ChangeFabricOreValue;
        _fabric.WoodAmountChanged += ChangeFabricWoodValue;
    }
    private void OnDisable()
    {
        resourcesCreation.OreAmountChanged -= ChangeOreValue;
        resourcesCreation.WoodAmountChanged -= ChangeWoodValue;
        _fabric.OreAmountChanged -= ChangeFabricOreValue;
        _fabric.WoodAmountChanged -= ChangeFabricWoodValue;
    }

    private void ChangeOreValue(int value)
    {
        _oreValueText.text = value.ToString();
    }
    private void ChangeWoodValue(int value)
    {
        _woodValueText.text = value.ToString();
    }
    private void ChangeFabricOreValue(int value)
    {
        _oreOnFabricValueText.text = value.ToString();
    }
    private void ChangeFabricWoodValue(int value)
    {
        _woodOnFabricValueText.text = value.ToString();
    }
}
