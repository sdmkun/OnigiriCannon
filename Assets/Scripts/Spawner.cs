using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnInterval;
	float timer;
	public GameObject spawnObject;
	GameObject spawnInstance;
	
	// Use this for initialization
	void Start () {
		timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer > spawnInterval) {
			spawnInstance = (GameObject)Instantiate(spawnObject, transform.position, transform.rotation);
			spawnInstance.transform.parent = transform.parent;
			timer = 0.0f;
		}
	}
}
