using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
	Animator animator;
	PlayerController playerMovement;
	bool isDead;
	bool damaged;
	PlayerShooting playerShooting;

	void Awake () {
		animator = GetComponent<Animator>();
		playerMovement = GetComponent<PlayerController>();
		currentHealth = startingHealth;
		playerShooting = GetComponentInChildren<PlayerShooting>();
	}
	
	void Update () {
		if(damaged){
			damageImage.color = flashColor;
		}
		else{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0 && !isDead){
			Death();
		}
	}

	void Death(){
		isDead = true;
		animator.SetTrigger("Die");
		playerMovement.enabled = false;
        playerShooting.enabled = false;
		playerShooting.enabled = false;
	}
}
