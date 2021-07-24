using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(EnemyHealth))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private PlayerHealth _playerHealth;
    private EnemyHealth _enemyHealth;

    public void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (_enemyHealth.currentHealth > 0 && _playerHealth.currentHealth > 0)
        {
            _navMeshAgent.SetDestination(_playerHealth.transform.position);
        }
        else
        {
            _navMeshAgent.enabled = false;
        }
    }
}
