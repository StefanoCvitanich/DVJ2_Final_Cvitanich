using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    private float zombieTimer;
	private float sorcererTimer;
	private float giantTimer;

    public GameObject zombie;
    public GameObject sorcerer;
	public GameObject giant;
    public GameObject player;
    public GameObject poolManager;

    // Use this for initialization
    void Start()
    {
		zombieTimer = 0;
		sorcererTimer = 0;
		giantTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

		zombieTimer += Time.deltaTime;
		sorcererTimer += Time.deltaTime;
		giantTimer += Time.deltaTime;

		if (zombieTimer >= 5) {
			spawnZombie ();
			zombieTimer = 0;
		}
		
		if (sorcererTimer >= 11) {
			spawnSorcerer ();
			sorcererTimer = 0;
		}
		
		if (giantTimer >= 23) {
			spawnGiant ();
			giantTimer = 0;
		}
    }

    private void spawnZombie()
    {
        poolManager.GetComponent<poolManager>().reuseObject(zombie, transform.position, transform.rotation);
    }

    private void spawnSorcerer()
    {
        poolManager.GetComponent<poolManager>().reuseObject(sorcerer, transform.position, transform.rotation);
    }

	private void spawnGiant()
	{
		poolManager.GetComponent<poolManager> ().reuseObject (giant, transform.position, transform.rotation);
	}
}