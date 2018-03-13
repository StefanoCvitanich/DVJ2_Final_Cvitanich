using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour {

    public GameObject player;
	public int spellDamage;

	private Vector3 targetPoint;

    private int speed = 7;
	float step;

	void OnEnable () {

		step = speed * Time.deltaTime;
		targetPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
		/*
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetPoint, step, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDir);
		*/
	}


	void Update () {

		transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);

		if (transform.position == targetPoint) {
			
			gameObject.GetComponent<poolObject>().destroy();
		}
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
			col.GetComponent<playerHealth>().damaged (spellDamage);
    }
}
