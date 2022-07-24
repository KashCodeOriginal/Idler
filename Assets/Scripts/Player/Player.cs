using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;
    
    [SerializeField] private Fabric _fabric;

    [SerializeField] private Storage _storage;

    [SerializeField] private SellToMarket _sellToMarket;

    [SerializeField] private int _coins;
    
    public event UnityAction<int> ChangeCoinsAmount;

    private void PlayerRun(bool isPlayerRunning)
    {
        _animator.SetBool("IsRunning", isPlayerRunning);
    }
    private void PlayerIdleingWithBoxes(bool isPlayerIdleingWithBoxes)
    {
        _animator.SetBool("IsCarrying", isPlayerIdleingWithBoxes);
    }
    private void PlayerRunningWithBoxes(bool isPlayerRunningWithBoxes)
    {
        _animator.SetBool("IsCarryingAndRunning", isPlayerRunningWithBoxes);
    }
    private void PlayerPlacingBox()
    {
        _animator.SetTrigger("Placing");
    }

    private void OnEnable()
    {
        _playerMovement.PlayerIsRunning += PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources += PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources += PlayerRunningWithBoxes;
        _fabric.PlacingBox += PlayerPlacingBox;
        _storage.PlacingBox += PlayerPlacingBox;
        
        _sellToMarket.CoinsAmountChanged += AddCoins;

        _sellToMarket.PlacingBox += PlayerPlacingBox;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerIsRunning -= PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources -= PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources -= PlayerRunningWithBoxes;
        _fabric.PlacingBox -= PlayerPlacingBox;
        _storage.PlacingBox -= PlayerPlacingBox;
        
        _sellToMarket.CoinsAmountChanged -= AddCoins;
        
        _sellToMarket.PlacingBox -= PlayerPlacingBox;
    }
    
    private void AddCoins(int value)
    {
        _coins += value;
        ChangeCoinsAmount?.Invoke(_coins);
    }
}
