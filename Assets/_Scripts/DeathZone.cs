using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;
            FindObjectOfType<SceneFader>().FadeToScene(currentScene);
        }
    }
}