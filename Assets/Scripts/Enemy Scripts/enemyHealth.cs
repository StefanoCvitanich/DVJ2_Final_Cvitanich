using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyHealth : MonoBehaviour {

    public int health;
	Vector3 spawnPos;

	public GameObject poolManager;
	public GameObject player;

	int randomNumber = -1;

	UnityEvent countingKilledSorcerers;

	// Use this for initialization
	void Start () {

		poolManager = GameObject.FindGameObjectWithTag ("poolManager");

		player = GameObject.FindGameObjectWithTag ("Player");

		spawnPos = new Vector3 (0, 0.5f, 0);

		if (countingKilledSorcerers == null)
			countingKilledSorcerers = new UnityEvent ();

		countingKilledSorcerers.AddListener (sorcererKilled);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void damaged(int dmg)
    {
        health -= dmg;

		if (health <= 0) {

			if (gameObject.tag == "sorcerer" && countingKilledSorcerers != null)
				countingKilledSorcerers.Invoke();
			
			gameObject.GetComponent<poolObject> ().destroy ();

			randomNumber = Random.Range (1, 4);

			//Debug.Log (randomNumber);

			if(randomNumber == 2){

				spawnPos += transform.position;
				poolManager.GetComponent<poolManager> ().reuseObject (poolManager.GetComponent<poolManager> ().healthItem, spawnPos, transform.rotation);
			}
		}
    }

    public void healed(int hld)
    {
        health += hld;
    }

	void sorcererKilled(){
		player.GetComponent<playerInteractions> ().killedSorcerers++;
	}
}
