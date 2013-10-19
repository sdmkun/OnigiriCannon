using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	
	float tsurami;
	public float maxTsurami;
	float okome;
	public float maxOkome;
	
	
	
	
	// Use this for initialization
	void Start () {
		tsurami = 0.0f;
		okome = maxOkome;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void ApplyDamage (float damage) {
		tsurami += damage;
	}
	
	public float GetOkome () {
		return okome;
	}
	
	public void SetOkome (float argOkome) {
		okome = argOkome;
	}
	
}
