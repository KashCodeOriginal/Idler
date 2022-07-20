using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    public void MovePlayer(FixedJoystick joystick)
    {
        _rigidbody.velocity = new Vector3(joystick.Horizontal * _speed, _rigidbody.velocity.y, joystick.Vertical * _speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {   
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }
}
