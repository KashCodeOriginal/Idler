using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;

    [SerializeField] private GameObject _box;

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

    private void OnEnable()
    {
        _playerMovement.PlayerIsRunning += PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources += PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources += PlayerRunningWithBoxes;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerIsRunning -= PlayerRun;
        _playerMovement.PlayerIsIdleingWithResources -= PlayerIdleingWithBoxes;
        _playerMovement.PlayerIsRunningWithResources -= PlayerRunningWithBoxes;
    }
}
