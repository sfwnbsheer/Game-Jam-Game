using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : MonoBehaviour
{
    public int currentLevel;

    void Start()
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= unlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel + 1);
            PlayerPrefs.Save();
        }
    }
}