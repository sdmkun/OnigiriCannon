using UnityEngine;
using System.Collections;

public class SoldierStatus : MonoBehaviour {
	
	public float maxHealth;
	float health;
	bool deadFlag = false;
	public int maxLevel;
	int level = 0;
	
	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(!deadFlag && health <= 0.0f) {
			health = 0.0f;
			deadFlag = true;
			SendMessage("Die");
		}
		if(health > maxHealth) {
			health = maxHealth;
		}
		gameObject.SendMessage("SetHealthRate", health / maxHealth, SendMessageOptions.DontRequireReceiver);
	}
	
	public void ApplyDamage(float damage) {
		health -= damage;
	}
	
	public bool isAlive() {
		return !deadFlag;
	}
	
	void LevelUp(int num) {
		level += num;
		maxHealth += 1.0f;
		health += 1.0f;
	}
	
	public bool isMaxLevel() {
		return (level >= maxLevel) ? true : false;
	}
}
