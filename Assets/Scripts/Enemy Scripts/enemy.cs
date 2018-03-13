using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class enemy : poolObject {

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setMovement(string mov)
    {

        gameObject.AddComponent<enemyMovement>();

        switch (mov)
        {
            case "walk":
                gameObject.GetComponent<enemyMovement>().speed = 3;
                break;

            case "run":
                gameObject.GetComponent<enemyMovement>().speed = 5;
                break;
        }
    }

    public void setAttack(string att)
    {
        gameObject.AddComponent<enemyAttack>();

        switch (att)
        {
            case "mele":
                gameObject.GetComponent<enemyAttack>().meleDamage = 2;
                gameObject.GetComponent<enemyAttack>().rangeDamage = 0;
                break;

            case "range":
                gameObject.GetComponent<enemyAttack>().meleDamage = 2;
                gameObject.GetComponent<enemyAttack>().rangeDamage = 4;
                break;
        }
    }

    public void setHealth(string hea)
    {
        gameObject.AddComponent<enemyHealth>();

        switch (hea)
        {
            case "low":
                gameObject.GetComponent<enemyHealth>().health = 5;
                break;

            case "med":
                gameObject.GetComponent<enemyHealth>().health = 7;
                break;

            case "high":
                gameObject.GetComponent<enemyHealth>().health = 9;
                break;
        }
    }

	// Tengo que hacer el override de on object reuse
}
*/