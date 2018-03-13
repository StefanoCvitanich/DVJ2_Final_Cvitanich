using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolManager : MonoBehaviour {

    public GameObject zombie;
    public GameObject sorcerer;
	public GameObject giant;
	public GameObject spell;
    public GameObject enemySpawner;
	public GameObject healthItem;
	public GameObject dagger;

    void Start() {

        enemySpawner.GetComponent<enemySpawner>().player = GameObject.FindGameObjectWithTag("Player");

        createPool(zombie, 45); //45

        createPool(sorcerer, 15); //15

		createPool (giant, 5); //5

		createPool (spell, 20); //20

		createPool (healthItem, 5);

		createPool (dagger, 10);

    }

	Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>();

	static poolManager _instance;

	public static poolManager instance {

		get{ 
			if (_instance == null)
				_instance = FindObjectOfType<poolManager> ();

			return _instance;
		}
	}

	public void createPool(GameObject prefab, int poolSize){
	
		int poolKey = prefab.GetInstanceID ();

		if (!poolDictionary.ContainsKey (poolKey)) {
		
			poolDictionary.Add (poolKey, new Queue<ObjectInstance> ());

			GameObject poolHolder = new GameObject (prefab.name + " pool");
			poolHolder.transform.parent = transform;

			for (int i = 0; i < poolSize; i++){
		
				ObjectInstance newObject = new ObjectInstance (Instantiate (prefab) as GameObject);
				poolDictionary [poolKey].Enqueue (newObject);

				newObject.setParent (poolHolder.transform);
			}
		}
	}

	public void reuseObject(GameObject prefab, Vector3 position, Quaternion rotation ){
	
		int poolKey = prefab.GetInstanceID ();

		if(poolDictionary.ContainsKey (poolKey)){

			ObjectInstance objectToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (objectToReuse);

            if (!objectToReuse.poolObjectScript.gameObject.activeSelf)
            {
                objectToReuse.reuse(position, rotation);
            }
		}
	}

	public class ObjectInstance {

		GameObject gameObject;
		Transform transform;

		bool hasPoolObjectComponent;
		public poolObject poolObjectScript;

		public ObjectInstance(GameObject objectInstance){

			gameObject = objectInstance;
			transform = gameObject.transform;
			gameObject.SetActive (false);

			if (gameObject.GetComponent<poolObject>()){

				hasPoolObjectComponent = true;
				poolObjectScript = gameObject.GetComponent<poolObject>();
			}
		}

		public void reuse(Vector3 position, Quaternion rotation){
		
			gameObject.SetActive (true);
			transform.position = position;
			transform.rotation = rotation;

			if (hasPoolObjectComponent) {

                //poolObjectScript.isSpawned = true;

				poolObjectScript.onObjectReuse (); // para volver atributos a default en caso de haber sido modificados.
			}
		}
	
		public void setParent (Transform parent){

			transform.parent = parent;
		}
	}
}
