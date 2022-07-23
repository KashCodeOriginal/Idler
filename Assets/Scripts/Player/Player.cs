using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private GameObject _box;

    [SerializeField] private Fabric _fabric;

    [SerializeField] private Storage _storage;

    private void PlayerRun(bool isPlayerRunning)
    {
        _animator.SetBool("IsRunning", isPlayerRunning);
        _box.SetActive(false);
    }
    private void PlayerIdleingWithBoxes(bool isPlayerIdleingWithBoxes)
    {
        _animator.SetBool("IsCarrying", isPlayerIdleingWithBoxes);
        _box.SetActive(true);
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
    }

    private void OnDisable()
    {
        _playerMovement.PlayerIsRunning -= PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources -= PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources -= PlayerRunningWithBoxes;
        _fabric.PlacingBox -= PlayerPlacingBox;
        _storage.PlacingBox -= PlayerPlacingBox;
    }
}
