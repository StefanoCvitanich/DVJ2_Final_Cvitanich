using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	void Awake(){
	
		GameObject[] musicArray = GameObject.FindGameObjectsWithTag ("music");

		if (musicArray.Length > 1)
			Destroy (this.gameObject);

		DontDestroyOnLoad (this.gameObject);
	}
}
