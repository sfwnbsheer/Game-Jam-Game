using UnityEngine;

public class HomeUIController : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject levelPanel;

    void Start()
    {
        homePanel.SetActive(true);
        levelPanel.SetActive(false);
    }

    public void OpenLevelPanel()
    {
        homePanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void BackToHome()
    {
        levelPanel.SetActive(false);
        homePanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}