using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject bottomUIPanel;
	public GameObject logoImage;
	public GameObject playButton;
	public GameObject loadingUI;
	public Text progressText;

	public void OnClickPlay() {
		StartCoroutine(LoadingScreenGame());
	}

	IEnumerator LoadingScreenGame(){
		bottomUIPanel.SetActive (false);
		logoImage.SetActive (false);
		playButton.SetActive (false);
		loadingUI.SetActive (true);
		var async = SceneManager.LoadSceneAsync ("Game");
		async.allowSceneActivation = false;
		while (async.isDone == false) {
			float textProgress = async.progress * 100;
			progressText.text = "Loading " + Mathf.Round(textProgress) + "%...";

			if (async.progress == 0.9f) {
				progressText.text = "Loading 100%...";
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
