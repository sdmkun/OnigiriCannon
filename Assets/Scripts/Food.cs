using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	
	public int maxAmount;
	public float deathTimer;
	int amount;
	
	// Use this for initialization
	void Start () {
		amount = maxAmount;
		Destroy(gameObject, deathTimer);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(1.0f * amount / maxAmount, 1.0f * amount / maxAmount, 1.0f * amount / maxAmount);
	}
	
	void Eaten () {
		--amount;
		if(amount <= 0) {
			Destroy(gameObject);
		}
	}
}
