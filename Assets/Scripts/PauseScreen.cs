using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public string mainScene;
    public GameObject thePauseScreen;

    public void PauseGame()
    {
        Time.timeScale = 0;
        thePauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainScene);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
}