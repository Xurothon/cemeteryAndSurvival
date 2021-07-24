using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class GameOver : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restastartDelay = 4f;
    private Animator _animator;
    private float _restastartTimer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            _animator.SetTrigger("GameOver");
            _restastartTimer += Time.deltaTime;
            if (_restastartTimer >= restastartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
