using UnityEngine;
using UnityEngine.Events;

public class FabricFill : MonoBehaviour
{
    public event UnityAction TryFillOreOnFabric;
    public event UnityAction TryFillWoodOnFabric;
    
    public void TryFillOre()
    {
        TryFillOreOnFabric?.Invoke();
    }

    public void TryFillWood()
    {
        TryFillWoodOnFabric?.Invoke();
    }
}
