using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtonsAndroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		if (Application.platform == RuntimePlatform.Android) {

			Debug.Log ("Detecto Android");

			if (!this.gameObject.activeInHierarchy) {
			
				Debug.Log ("detecto que esta apagado");

				this.gameObject.SetActive (true);

				Debug.Log ("Lo prendio");
			}
				
		}

		else
			this.gameObject.SetActive (false);

		Debug.Log ("Detecto que no esta en Android");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
