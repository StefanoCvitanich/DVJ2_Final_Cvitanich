using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthItemBehaviour : MonoBehaviour {

	Vector3 rotVec = new Vector3 (0,1,0);

	float timer = 0;
	float lifeExpectancy = 30;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		//Debug.Log (timer);

		if (timer >= lifeExpectancy)
			gameObject.GetComponent<poolObject> ().destroy ();

		transform.Rotate (rotVec);

	}

	void OnTriggerEnter(Collider col) {

		if (col.gameObject.tag == "Player") {

			col.gameObject.GetComponent<playerHealth> ().health += 10;

			gameObject.GetComponent<poolObject> ().destroy ();
		}
	}
}
