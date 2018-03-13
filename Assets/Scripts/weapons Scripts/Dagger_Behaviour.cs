using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger_Behaviour : MonoBehaviour {

	public int daggerDamage = 1;

	float timer;

	// Use this for initialization
	void Start () {

		timer = 0;

		//transform.rotation = Quaternion.AngleAxis (180, transform.parent.up);

		//transform.eulerAngles = new Vector3 (0, 180, 0);
	}

    private void OnEnable()
    {

    }

    // Update is called once per frame
    void Update () {

		timer += Time.deltaTime;

		gameObject.transform.position += (gameObject.transform.forward) * 1/2;

		if (timer > 5) {
			gameObject.GetComponent<poolObject> ().destroy ();
			timer = 0;
		}

	}

	void OnTriggerEnter(Collider col){
	
		if (col.tag == "zombie" || col.tag == "sorcerer" || col.tag == "giant") {
		
			col.GetComponent<enemyHealth> ().damaged (daggerDamage);

		}

		if(col.gameObject.tag != "dagger" && col.gameObject.tag != "Player")
			gameObject.GetComponent<poolObject> ().destroy ();
	}
}
