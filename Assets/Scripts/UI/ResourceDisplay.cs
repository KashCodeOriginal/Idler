using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _oreValueText;
    [SerializeField] private TMP_Text _woodValueText;
    
    [SerializeField] private TMP_Text _oreOnFabricValueText;
    [SerializeField] private TMP_Text _woodOnFabricValueText;
    
    [SerializeField] private TMP_Text _ingotsOnFabricValueText;
    [SerializeField] private TMP_Text _planksOnFabricValueText;
    
    [SerializeField] private TMP_Text _oreInStorageValueText;
    [SerializeField] private TMP_Text _woodInStorageValueText;
    
    [SerializeField] private TMP_Text _ingotsInStorageValueText;
    [SerializeField] private TMP_Text _planksInStorageValueText;


    [SerializeField] private ResourcesCreation resourcesCreation;
    [SerializeField] private Fabric _fabric;
    [SerializeField] private Storage _storage;

    private void OnEnable()
    {
        resourcesCreation.OreAmountChanged += ChangeOreValue;
        resourcesCreation.WoodAmountChanged += ChangeWoodValue;
        _fabric.OreAmountChanged += ChangeFabricOreValue;
        _fabric.WoodAmountChanged += ChangeFabricWoodValue;
        _fabric.IngotsAmountChanged += ChangeFabricIngotsValue;
        _fabric.PlanksAmountChanged += ChangeFabricPlanksValue;
        _storage.OreStorageAmountChanged += ChangeStorageOreValue;
        _storage.WoodStorageAmountChanged += ChangeStorageWoodValue;
        _storage.IngotStorageAmountChanged += ChangeStorageIngotsValue;
        _storage.PlankStorageAmountChanged += ChangeStoragePlanksValue;
    }
    private void OnDisable()
    {
        resourcesCreation.OreAmountChanged -= ChangeOreValue;
        resourcesCreation.WoodAmountChanged -= ChangeWoodValue;
        _fabric.OreAmountChanged -= ChangeFabricOreValue;
        _fabric.WoodAmountChanged -= ChangeFabricWoodValue;
        _fabric.IngotsAmountChanged -= ChangeFabricIngotsValue;
        _fabric.PlanksAmountChanged -= ChangeFabricPlanksValue;
        _storage.OreStorageAmountChanged -= ChangeStorageOreValue;
        _storage.WoodStorageAmountChanged -= ChangeStorageWoodValue;
        _storage.IngotStorageAmountChanged -= ChangeStorageIngotsValue;
        _storage.PlankStorageAmountChanged -= ChangeStoragePlanksValue;
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
    private void ChangeFabricIngotsValue(int value)
    {
        _ingotsOnFabricValueText.text = value.ToString();
    }
    private void ChangeFabricPlanksValue(int value)
    {
        _planksOnFabricValueText.text = value.ToString();
    }
    private void ChangeStorageOreValue(int value)
    {
        _oreInStorageValueText.text = value.ToString();
    }
    private void ChangeStorageWoodValue(int value)
    {
        _woodInStorageValueText.text = value.ToString();
    }
    private void ChangeStorageIngotsValue(int value)
    {
        _ingotsInStorageValueText.text = value.ToString();
    }
    private void ChangeStoragePlanksValue(int value)
    {
        _planksInStorageValueText.text = value.ToString();
    }
}
