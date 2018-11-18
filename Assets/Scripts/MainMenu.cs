using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string firstLevel;
    public int startingLives;
    int currentLevel = 1;

    public void NewGame() {
        SceneManager.LoadScene(firstLevel);
        PlayerPrefs.SetInt("PlayerLives", startingLives);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
