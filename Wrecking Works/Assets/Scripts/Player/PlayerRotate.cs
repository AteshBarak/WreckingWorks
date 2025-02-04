using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    public Joystick joystick;
    public float rotationSpeed;
    private Quaternion targetRotation;
    private bool isMoving = false;

    private void Start()
    {
        targetRotation = transform.rotation;
    }

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        if (horizontalInput != 0 || verticalInput != 0)
        {
            isMoving = true;
            Vector3 lookDirection = new Vector3(horizontalInput, 0, verticalInput);
            targetRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
        else if (isMoving)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
