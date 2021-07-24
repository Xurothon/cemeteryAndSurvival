using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator), typeof(PlayerController), typeof(PlayerShooting))]
public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    private Animator _animator;
    private PlayerController _playerMovement;
    private bool _isDead;
    private bool _isDamaged;
    private PlayerShooting _playerShooting;

    public void TakeDamage(int amount)
    {
        _isDamaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !_isDead)
        {
            Death();
        }
    }

    void Death()
    {
        _isDead = true;
        _animator.SetTrigger("Die");
        _playerMovement.enabled = false;
        _playerShooting.enabled = false;
    }

    public void SaveHealth()
    {
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            PlayerPrefs.SetInt("PlayerLives", currentHealth);
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.HasKey("PlayerLives"))
        {
            startingHealth = PlayerPrefs.GetInt("PlayerLives");
        }
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerController>();
        _playerShooting = GetComponent<PlayerShooting>();
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if (_isDamaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        _isDamaged = false;
    }
}