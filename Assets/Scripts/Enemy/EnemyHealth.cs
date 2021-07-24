using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(CapsuleCollider))]
public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 90;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public GameObject enemyHP;
    public EnemyHp enemySlider;
    public UnityEvent OnDestroy;
    public int buff;
    private Animator _animator;
    private CapsuleCollider _capsuleCollider;
    private bool _isDead;
    private bool _isSinking;

    public void TakeDamage(int amount)
    {
        if (_isDead) return;
        currentHealth -= amount;
        enemySlider.currentHp = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        _isDead = true;
        _capsuleCollider.isTrigger = true;
        Destroy(enemySlider.gameObject);
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        _animator.SetTrigger("Dead");
    }

    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        _isSinking = true;
        Destroy(gameObject, 1.5f);
    }

    private void Start()
    {
        GameObject hp = Instantiate(enemyHP, Vector3.zero, Quaternion.identity);
        hp.transform.SetParent(GameObject.Find("Canvas").transform);
        hp.transform.SetAsFirstSibling();
        enemySlider = hp.GetComponent<EnemyHp>();
        enemySlider.Enemy = gameObject;
        startingHealth += (buff * 5);
        enemySlider.ChangeValue(startingHealth);
        currentHealth = startingHealth;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (_isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

}
