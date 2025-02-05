using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Character Controller Component")]
    public CharacterController controller;

    [Header("Movement Settings")]
    public float moveSpeed;

    public Joystick joystick;
    public PlayerSound sound;

    private float joystickMagnitude;

    public bool isMaxSpeed = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Speed"))
        {
            moveSpeed = PlayerPrefs.GetFloat("Speed");
        }
    }

    public void ChangeMaxSpeed()
    {
        if (PlayerPrefs.HasKey("LevelSpeed"))
        {
            if (PlayerPrefs.GetInt("LevelSpeed") < 3)
            {
                moveSpeed += 1.5f;
            }
            else if (PlayerPrefs.GetInt("LevelSpeed") < 6)
            {
                moveSpeed += 0.75f;
            }
            else if (PlayerPrefs.GetInt("LevelSpeed") < 10)
            {
                moveSpeed += 0.5f;
            }
            else
            {
                moveSpeed += 0.1f;
            }
        }

        if (moveSpeed > 30)
        {
            moveSpeed = 30;
        }

        PlayerPrefs.SetFloat("Speed", moveSpeed);
        sound.PlayUpgrade();
    }

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
        if (!isMaxSpeed)
        {
            controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
        else
        {
            float _speed = moveSpeed;
            if (moveSpeed < 25)
            {
                _speed += 8;
            }
            else
            {
                _speed += 5;
            }
            controller.Move(moveDirection * _speed * Time.deltaTime);
        }
    }

    private Vector3 GetMoveDirection()
    {
        return transform.forward * joystickMagnitude;
    }

}
