using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public void play(){

		GameObject[] musicToMute = GameObject.FindGameObjectsWithTag ("music");

		if (musicToMute.Length > 0) {

			foreach (GameObject music in musicToMute) {

				Destroy (music);
			}
		}
	
		SceneManager.LoadScene ("Gameplay");
	}

	public void mainMenu(){
	
		SceneManager.LoadScene ("Main Menu");
	}

	public void howToPlay(){
	
		SceneManager.LoadScene ("How to Play");
	}

	public void exit(){
	
		Application.Quit ();
	}

	public void credits(){
	
		SceneManager.LoadScene ("Credits");
	}
}
