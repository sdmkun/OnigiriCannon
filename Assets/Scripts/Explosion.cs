using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	
	public GameObject explosion;
	public GameObject food;
	
	bool isStillExplode = false;
	public int radius;
	public float maxDamage;
	
	public float deathTimer;
	
	GameObject explosionInstance;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void OnCollisionEnter(Collision collision) {
		if(!isStillExplode && collision.rigidbody && collision.rigidbody.name != "OnigiriExplosive" && collision.rigidbody.name != "tank" &&
									collision.rigidbody.name != "Chunk(Clone)" && collision.rigidbody.name != "Wall") {
			isStillExplode = true;
			explosionInstance = (GameObject)Instantiate(explosion, rigidbody.position, rigidbody.rotation);
			explosionInstance.transform.parent = transform.parent;
			Damage();
			SendMessage("PlaySound", 0, SendMessageOptions.DontRequireReceiver);
		}
		//GameObject onigiri = (GameObject)Instantiate(food, transform.position, transform.rotation);
		gameObject.tag = "Food";
		Destroy(gameObject, deathTimer);
	}
	
	void Damage() {
		float damage;
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach (Collider obj in colliders) {
			if((obj) && (obj.tag == "Enemy")) {
				damage = maxDamage * (1.0f - Vector3.Distance(obj.transform.position, transform.position) / radius);
				obj.gameObject.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
        }
	}
		
	
}
