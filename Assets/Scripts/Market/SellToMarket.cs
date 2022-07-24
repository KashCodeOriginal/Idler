using UnityEngine;
using UnityEngine.Events;

public class SellToMarket : MonoBehaviour
{
    [SerializeField] private PlayerInventory _playerInventory;

    [SerializeField] private MarketItemsSwitch _marketItemsSwitch;

    public event UnityAction GetOreValueInInventory;
    public event UnityAction GetWoodValueInInventory;
    public event UnityAction GetIngotValueInInventory;
    public event UnityAction GetPlankValueInInventory;
    
    public void SellItem()
    {
        switch (_marketItemsSwitch.CurrentItemId)
        {
            case 0:
                GetOreValueInInventory?.Invoke();
                break;
            case 1:
                GetWoodValueInInventory.Invoke();
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
