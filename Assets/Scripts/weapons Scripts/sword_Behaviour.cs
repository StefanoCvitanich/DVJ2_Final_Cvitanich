using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword_Behaviour : MonoBehaviour {

	public int meleDamage = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "zombie" || col.gameObject.tag == "sorcerer" || col.gameObject.tag == "giant") {

			col.gameObject.GetComponent<enemyHealth> ().damaged (meleDamage);
		}

	}
}
