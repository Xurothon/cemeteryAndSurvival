using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damagePerShot = 20;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(damagePerShot);
        }
    }

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }
}
