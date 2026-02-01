using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public FallingObstacle obstacle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            obstacle.Fall();
        }
    }
}

