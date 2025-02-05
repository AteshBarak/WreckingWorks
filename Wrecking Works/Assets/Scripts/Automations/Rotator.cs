using UnityEngine;

[DisallowMultipleComponent]
public class Rotator : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] Vector3 rotationVector;
    [SerializeField] float rotaionSpeed;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(rotationVector * rotaionSpeed * Time.deltaTime);
    }
}
