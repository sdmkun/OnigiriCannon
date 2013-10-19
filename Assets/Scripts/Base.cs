using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
	
	public float hitpoint;
	public float maxHitpoint;
	public string holder;	//所有者（タグ）
	string tempHolder;		//暫定的所有者
	bool stillDominated;
	
	Material mat;

	// Use this for initialization
	void Start () {
		hitpoint = 0;//maxHitpoint;
		mat = renderer.material;
	}
	
	// Update is called once per frame
	void Update () {
		if(hitpoint >= maxHitpoint) {
			hitpoint = maxHitpoint;
			if(!stillDominated) {
				SendMessage("PlaySoundSingle", 3, SendMessageOptions.DontRequireReceiver);
			}
			stillDominated = true;
		} else {
			stillDominated = false;
			transform.tag = "AttackableTarget";
		}
		
		//mat.SetColor("_Color", new Color((tempHolder == "Friendly")? hitpoint / maxHitpoint : 0.0f, 0.0f, (tempHolder == "Enemy")? hitpoint / maxHitpoint : 0.0f));
		if(tempHolder == "Friendly") {
			mat.SetColor("_Color", new Color(1.0f, 1.0f - hitpoint / maxHitpoint, 1.0f - hitpoint / maxHitpoint));
		} else {
			mat.SetColor("_Color", new Color(1.0f - hitpoint / maxHitpoint, 1.0f - hitpoint / maxHitpoint, 1.0f));
		}
		
	}
	
	public void Dominated(float damage, string tag) {
		if(tag != tempHolder) {
			hitpoint -= damage;
			if(hitpoint <= 0.0f) {
				tempHolder = tag;
				holder = "AttackableTarget";
				gameObject.tag = "AttackableTarget";
				hitpoint = -hitpoint;
			}
		} else {
			hitpoint += damage;
			if(hitpoint >= maxHitpoint) {
				tempHolder = tag;
				holder = tag;
				gameObject.tag = tag;
			}
		}
	}
	
}
