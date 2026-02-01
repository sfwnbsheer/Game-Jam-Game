using UnityEngine;

public class MaskFloatRotate : MonoBehaviour
{
    [Header("Float Settings")]
    public float floatHeight = 0.25f;
    public float floatSpeed = 2f;

    [Header("Rotate Settings")]
    public float rotateSpeed = 50f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Floating (sin wave)
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = startPos + Vector3.up * yOffset;

        // Rotation
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
