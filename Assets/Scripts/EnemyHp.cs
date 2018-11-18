using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour {
	
	public int currentHp = 100;
	public GameObject Enemy;
	public Vector3 offcet;

	void Update () {
		GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(Enemy.transform.position + offcet);
		GetComponent<Slider>().value = currentHp;
	}

	public void ChangeValue(int value){
		GetComponent<Slider>().maxValue = value;
		currentHp = value;
	}
}
