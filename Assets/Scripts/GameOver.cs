using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public string mainScene;
	public PlayerHealth playerHealth;
	public float restastartDelay = 4f;

	Animator animator;
	float restastartTimer;
	void Awake () {
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		if(playerHealth.currentHealth <= 0){
			animator.SetTrigger("GameOver");
			restastartTimer += Time.deltaTime;
			if(restastartTimer >= restastartDelay){
				SceneManager.LoadScene(mainScene);
			}
		}
	}
}
