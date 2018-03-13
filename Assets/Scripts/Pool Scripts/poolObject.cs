using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolObject : MonoBehaviour {

    //public bool isSpawned = false;

	public virtual void onObjectReuse () {
		
	}

	public void destroy(){

		//MALISIMA IDEA!!! SE CONGELA EL JUEGO!!!
		/*
		if (gameObject.tag == "spell") {

			float timer = 0;

			do{
				timer += Time.deltaTime;
				Debug.Log(timer);
			}
			while (timer < 1); //para darle un tiempo de vida al spell luego de haber alcanzado su objetivo
		}
		*/

		gameObject.SetActive (false);
	}
}