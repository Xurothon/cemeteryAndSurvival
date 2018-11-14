using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaterial : MonoBehaviour {

	public Texture[] materials;
	Material myMaterial; 
	void Awake () {
		myMaterial = GetComponent<Renderer>().material;
		myMaterial.mainTexture = materials[Random.Range(0, materials.Length)];
	}

}
