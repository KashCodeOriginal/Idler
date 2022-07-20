using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;

    private void FixedUpdate()
    {
        gameObject.GetComponent<PlayerMovement>().MovePlayer(_joystick);
    }
}
