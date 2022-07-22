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

    [SerializeField] private ResourcesCreation resourcesCreation;
    [SerializeField] private Fabric _fabric;

    private void OnEnable()
    {
        resourcesCreation.OreAmountChanged += ChangeOreValue;
        resourcesCreation.WoodAmountChanged += ChangeWoodValue;
        _fabric.OreAmountChanged += ChangeFabricOreValue;
        _fabric.WoodAmountChanged += ChangeFabricWoodValue;
        _fabric.IngotsAmountChanged += ChangeFabricIngotsValue;
        _fabric.PlanksAmountChanged += ChangeFabricPlanksValue;
    }
    private void OnDisable()
    {
        resourcesCreation.OreAmountChanged -= ChangeOreValue;
        resourcesCreation.WoodAmountChanged -= ChangeWoodValue;
        _fabric.OreAmountChanged -= ChangeFabricOreValue;
        _fabric.WoodAmountChanged -= ChangeFabricWoodValue;
        _fabric.IngotsAmountChanged -= ChangeFabricIngotsValue;
        _fabric.PlanksAmountChanged -= ChangeFabricPlanksValue;
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
}
