using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Character Controller Component")]
    public CharacterController controller;

    [Header("Movement Settings")]
    public float moveSpeed;

    public Joystick joystick;

    private float joystickMagnitude;

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float newJoystickMagnitude = Mathf.Abs(joystick.Vertical) + Mathf.Abs(joystick.Horizontal);
        if (newJoystickMagnitude > 0.05f)
        {
            joystickMagnitude = Mathf.Clamp01(newJoystickMagnitude);
            Move();
        }
    }

    private void Move()
    {
        Vector3 moveDirection = GetMoveDirection();
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private Vector3 GetMoveDirection()
    {
        return transform.forward * joystickMagnitude;
    }

}
