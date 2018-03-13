using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

    public int health = 30;
	public Text healthText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		healthText.text = "Health: " + health;

	}

	public void damaged(int dmg){
	
		health -= dmg;

		if (health <= 0) {

			SceneManager.LoadScene ("Game Over");
		}
	}

	void OnTriggerEnter(Collider col){

		if(col.gameObject.tag == "abyss")
			SceneManager.LoadScene ("Game Over");
	}
}
