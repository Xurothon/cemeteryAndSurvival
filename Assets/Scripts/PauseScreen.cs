using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

    public string mainScene;
    public GameObject thePauseScreen;
    private PlayerController thePlayer;
	void Start () {
		
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
	}
	public void PauseGame() {
        Time.timeScale = 0;
        thePauseScreen.SetActive(true);
    }

	public void ResumeGame() {
        thePauseScreen.SetActive(false);
		Time.timeScale = 1f;
    }
	public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainScene);
    }
}
