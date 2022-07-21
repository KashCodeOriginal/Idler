using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private PlayerMovement _playerMovement;

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
