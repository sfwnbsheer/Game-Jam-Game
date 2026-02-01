using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            FindObjectOfType<SceneFader>().FadeToScene(currentScene);
        }
    }
}