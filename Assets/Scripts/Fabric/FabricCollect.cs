using UnityEngine;
using UnityEngine.Events;

public class FabricCollect : MonoBehaviour
{
    public event UnityAction TryCollectIngotOnFabric;
    public event UnityAction TryCollectPlankOnFabric;
    
    public void TryCollectIngot()
    {
        TryCollectIngotOnFabric?.Invoke();
    }

    public void TryCollectPlank()
    {
        TryCollectPlankOnFabric?.Invoke();
    }
}
