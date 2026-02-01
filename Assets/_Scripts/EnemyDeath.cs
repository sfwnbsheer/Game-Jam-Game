using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [Header("Mask Drop")]
    [SerializeField] private GameObject maskPrefab;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            maskPrefab.SetActive(true);
            other.gameObject.SetActive(false);
            AudioManager.Instance?.EnemyDie();
        }
    }
}
