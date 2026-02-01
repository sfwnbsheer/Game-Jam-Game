using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            FindObjectOfType<SceneFader>().FadeToScene(nextSceneName);
        }
    }
}