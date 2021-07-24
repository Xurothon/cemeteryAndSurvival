using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    private void EndScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            playerController.enabled = false;
            other.GetComponentInChildren<PlayerShooting>().enabled = false;
            other.GetComponent<Animator>().SetTrigger("Reduce");
            other.GetComponent<PlayerHealth>().SaveHealth();
            Invoke("EndScene", 2.0f);
        }
    }
}