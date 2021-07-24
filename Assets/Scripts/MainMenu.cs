using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public int startingLives;
    private int _currentLevel = 1;

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
        PlayerPrefs.SetInt("PlayerLives", startingLives);
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
