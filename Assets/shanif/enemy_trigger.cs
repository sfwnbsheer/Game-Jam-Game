using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyAttack enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.Follow();
        }
    }
}