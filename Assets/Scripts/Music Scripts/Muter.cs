using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muter : MonoBehaviour {

	void Awake (){
	
		GameObject[] musicToMute = GameObject.FindGameObjectsWithTag ("music");

		if (musicToMute.Length > 0) {
		
			foreach (GameObject music in musicToMute) {
				
				Destroy (music);
			}
		}
	}
}
