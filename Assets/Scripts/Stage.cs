using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{

    PlayerController playerMovement;
	PlayerShooting playerShooting;
    Animator animator;
	PlayerHealth playerHealth;
	public string firstLevel;

    void OnTriggerEnter(Collider other)
    {
		if(other.gameObject.tag == "Player"){
			playerMovement = other.gameObject.GetComponent<PlayerController>();
			playerShooting = other.gameObject.GetComponentInChildren<PlayerShooting>();
			animator = other.gameObject.GetComponent<Animator>();
			playerHealth = other.gameObject.GetComponent<PlayerHealth>();
			playerMovement.enabled = false;
        	playerShooting.enabled = false;
			playerHealth.SaveHealth();
			animator.SetTrigger("Reduce");
			Invoke("endScene", 2.0f);
		}
    }

	void endScene(){
		SceneManager.LoadScene(firstLevel);
	}
}
