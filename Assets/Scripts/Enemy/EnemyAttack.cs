using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyHealth))]
public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    private Animator _animator;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;
    private bool _isPlayerInRange;
    private float _timer;
    private int _buff;

    public void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Attack()
    {
        _timer = 0f;
        if (_playerHealth.currentHealth > 0)
        {
            _playerHealth.TakeDamage(attackDamage);
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _buff = _enemyHealth.buff;
        attackDamage += _buff;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            _isPlayerInRange = false;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeBetweenAttacks && _isPlayerInRange && _enemyHealth.currentHealth > 0)
        {
            Attack();
        }
        if (_playerHealth.currentHealth <= 0)
        {
            _animator.SetTrigger("PlayerDead");
        }
    }
}
