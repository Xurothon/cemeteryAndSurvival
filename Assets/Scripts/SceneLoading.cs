using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour {

	public string sceneName;
	public Slider slider;
	public Text progressText;

	void Start () {
		StartCoroutine(AsyncLoad());
	}
	
	IEnumerator AsyncLoad(){
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
		while(!operation.isDone){
			float progress = operation.progress;
			slider.value = progress;
			progressText.text = string.Format("{0:0}%", progress*100);
			yield return null; 
		}
	}
}
