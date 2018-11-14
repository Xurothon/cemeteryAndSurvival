using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
	
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	Animator animator;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;
	public GameObject enemyHP;
	public Vector3 offset;
	public EnemyHp enemySlider;

	void Start(){
		GameObject hp = Instantiate(enemyHP, Vector3.zero, Quaternion.identity) as GameObject;
		hp.transform.SetParent(GameObject.Find("Canvas").transform);
		hp.transform.SetAsFirstSibling();
 		hp.GetComponent<EnemyHp>().Enemy = gameObject;
		enemySlider = hp.GetComponent<EnemyHp>();
	}
	void Awake () {
		animator = GetComponent<Animator>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		currentHealth = startingHealth;
	}
	
	void Update () {
		if(isSinking){
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage(int amount){
		if(isDead) return;
		currentHealth -= amount;
		enemySlider.currentHp = currentHealth;
		if(currentHealth <= 0){
			Death();
		}
	}

	void Death(){
		isDead = true;
		capsuleCollider.isTrigger = true;
		Destroy(enemySlider.gameObject);
		animator.SetTrigger("Dead");
	}

	public void StartSinking(){
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
		GetComponent<Rigidbody>().isKinematic = true;
		isSinking = true;
		Destroy(gameObject, 1.5f);
	}
}
