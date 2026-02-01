using UnityEngine;

public class StoneDoorTrigger : MonoBehaviour
{
    public Transform door;          // Stone door
    public float moveDownDistance = 3f;
    public float speed = 2f;

    private bool openDoor = false;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = door.position - new Vector3(0, moveDownDistance, 0);
    }

    void Update()
    {
        if (openDoor)
        {
            door.position = Vector3.MoveTowards(
                door.position,
                targetPosition,
                speed * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            openDoor = true;
        }
    }
}
