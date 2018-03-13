using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class playerInteractions : MonoBehaviour {

	public Camera[] cams;
	public GameObject armoryText;
	public GameObject towerText;

	private GameObject interactButton;

	private bool swapWeaponPossible = false;
	private bool enterTowerPossible = false;

	GameObject sword;
	GameObject dagger;

	bool daggerEnabled;

	public int killedSorcerers = 0;

	UnityEvent enableDagger;

	// Use this for initialization
	void Start () {

		sword = GameObject.FindGameObjectWithTag ("sword");

		dagger = GameObject.FindGameObjectWithTag ("displayDagger");
		dagger.SetActive (false);

		if (enableDagger == null)
			enableDagger = new UnityEvent ();

		enableDagger.AddListener (unlockDagger);

		if (Application.platform == RuntimePlatform.Android) {
			interactButton = GameObject.Find ("Interact Button");
			Button btn = interactButton.GetComponent<Button> (); 
			btn.onClick.AddListener (AndroidInteraction);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(!daggerEnabled)
			if (killedSorcerers >= 1)
				enableDagger.Invoke ();
	}

	void OnTriggerStay(Collider col){
	
		if (col.tag == "armory") {

			if (!armoryText.activeInHierarchy)
				armoryText.SetActive (true);

			if (Application.platform == RuntimePlatform.Android) {
			
				swapWeaponPossible = true;
			}

			else if (Input.GetKeyUp (KeyCode.F)) {

				if (daggerEnabled) {
					
					if (sword.activeSelf) {

						sword.SetActive (false);
						dagger.SetActive (true);
					} else {

						dagger.SetActive (false);
						sword.SetActive (true);
					}
				}
			}

		} else if (col.name == "Tower_Door") {
		
			if (!towerText.activeInHierarchy)
				towerText.SetActive (true);

			if (Application.platform == RuntimePlatform.Android) {

				enterTowerPossible = true;
			}

			else if (Input.GetKeyUp (KeyCode.F)) {

				if (cams [0].enabled) {
				
					cams [0].enabled = false;
					cams [1].enabled = true;

					gameObject.GetComponent<playerMovement> ().insideTower = true;
				} 
				else {

					cams [0].enabled = true;
					cams [1].enabled = false;

					gameObject.GetComponent<playerMovement> ().insideTower = false;
				}
			}
		}
	}

	public void unlockDagger(){

		daggerEnabled = true;
	}

	void OnTriggerExit (Collider col){
	
		if(armoryText.activeInHierarchy)
			armoryText.SetActive (false);

		if(towerText.activeInHierarchy)
			towerText.SetActive (false);


		if (col.gameObject.tag == "armory")
			swapWeaponPossible = false;
		
		else if (col.gameObject.tag == "Tower_Door")
			enterTowerPossible = false;
	}

	void AndroidInteraction(){

		if (Application.platform == RuntimePlatform.Android) {

			if (swapWeaponPossible) {

				if (daggerEnabled) {

					if (sword.activeSelf) {

						sword.SetActive (false);
						dagger.SetActive (true);
					} else {

						dagger.SetActive (false);
						sword.SetActive (true);
					}
				}
			} 

			else if (enterTowerPossible) {
			
				if (cams [0].enabled) {

					cams [0].enabled = false;
					cams [1].enabled = true;

					gameObject.GetComponent<playerMovement> ().insideTower = true;
				} 
				else {

					cams [0].enabled = true;
					cams [1].enabled = false;

					gameObject.GetComponent<playerMovement> ().insideTower = false;
				}
			}
		}
	}
}
