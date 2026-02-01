using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;          // 1,2,3...
    public int totalPlayableLevels;  // example: 5

    void Start()
    {
        Button btn = GetComponent<Button>();

        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Disable dummy buttons
        if (levelNumber > totalPlayableLevels)
        {
            btn.interactable = false;
            return;
        }

        // Lock / Unlock real levels
        btn.interactable = levelNumber <= unlocked;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_" + levelNumber);
    }
}
