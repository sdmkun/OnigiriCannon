using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public int spawnInterval;
	public GameObject spawnObject;
	FrameCounter frameCounter;
	GameObject spawnInstance;
	
	// Use this for initialization
	void Start () {
		frameCounter = (FrameCounter)transform.parent.gameObject.GetComponent(typeof(FrameCounter));
	}
	
	// Update is called once per frame
	void Update () {
		if(frameCounter.GetFrame() % spawnInterval == 0) {
			spawnInstance = (GameObject)Instantiate(spawnObject, transform.position, transform.rotation);
			spawnInstance.transform.parent = transform.parent;
		}
	}
}
