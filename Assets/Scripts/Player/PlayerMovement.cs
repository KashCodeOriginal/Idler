using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    [SerializeField] private PlayerInventory _playerInventory;

    public event UnityAction<bool> PlayerIsRunning;
    public event UnityAction<bool> PlayerIsIdleingWithResources;
    public event UnityAction<bool> PlayerIsRunningWithResources;

    public void MovePlayer(FixedJoystick joystick)
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * _speed, _rigidbody.velocity.y, joystick.Vertical * _speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {   
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            
            if (_playerInventory.OreAmount > 0 || _playerInventory.WoodAmount > 0)
            {
                PlayerIsIdleingWithResources?.Invoke(false);
                PlayerIsRunningWithResources?.Invoke(true);
            }
            else
            {
                PlayerIsRunning?.Invoke(true);
            }
        }
        else
        {
            if (_playerInventory.OreAmount > 0 || _playerInventory.WoodAmount > 0)
            {
                PlayerIsRunningWithResources?.Invoke(false);
                PlayerIsIdleingWithResources?.Invoke(true);
            }
            else
            {
                PlayerIsRunning?.Invoke(false);
            }
        }
    }
}
