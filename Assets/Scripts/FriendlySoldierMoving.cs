using UnityEngine;
using System.Collections;

public class FriendlySoldierMoving : SoldierMoving {
	
	public float attackDamage;
	
	
	SoldierStatus soldierStatus;
	
	// Use this for initialization
	new void Start () {
		base.Start();
		soldierStatus = transform.GetComponent<SoldierStatus>();
		standingRotation = Quaternion.Euler(new Vector3(0, 0, 0));
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
	}
	
	override protected void PlayStateWalk() {
		bool aloneFlag = true;
		if(onSurface) {
			if(Mathf.Abs(rigidbody.velocity.x) < maxSpeed) {
				rigidbody.AddForce(moveForce, 0.0f, 0.0f);
			}
			standingRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f + 35.0f * Mathf.Sin((Time.time - startTime) * 5), 0.0f));
			ModifyPosition();
			
			Collider[] colliders = Physics.OverlapSphere(transform.position, fightRadius);
			foreach (Collider obj in colliders) {
				if((obj) && (obj.tag == "Enemy" || obj.tag == "AttackableTarget")) {
					stateChange(State.fight);
				} else if((obj) && (obj.tag == "Friendly") && obj.transform != transform) {
					aloneFlag = false;
					if(Mathf.Sign(transform.position.z - obj.transform.position.z) == Mathf.Sign (transform.position.z)){
						standingPosition = new Vector3(transform.position.x, transform.position.y, obj.transform.position.z + 1.0f * Mathf.Sign(transform.position.z - obj.transform.position.z));
					} else {
						standingPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
					}
				} else if(!soldierStatus.isMaxLevel() && (obj) && (obj.tag == "Food")) {
					stateChange(State.eat);
				}
			}
			if(aloneFlag) {
				standingPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
			}
		}
	}
	
	override protected void PlayStateFight() {
		if(onSurface) {
			rigidbody.AddForce(0.0f, 60.0f, 0.0f);
			SendMessage("PlaySoundSingle", 1, SendMessageOptions.DontRequireReceiver);
		}
		
		ModifyPosition();
		
		bool fightFlag = false;
		bool aloneFlag = true;
		Collider[] colliders = Physics.OverlapSphere(transform.position, fightRadius);
		foreach (Collider obj in colliders) {
			if((obj) && (obj.tag == "Enemy" || obj.tag == "AttackableTarget")) {
				fightFlag = true;
				obj.SendMessage("ApplyDamage", attackDamage * Time.deltaTime, SendMessageOptions.DontRequireReceiver);
				if(obj.name == "Base") {
					DominateBase(obj.transform, attackDamage * Time.deltaTime);
				}
			} else if((obj) && (obj.tag == "Friendly") && obj.transform != transform) {
				aloneFlag = false;
				if(Mathf.Sign(transform.position.z - obj.transform.position.z) == Mathf.Sign (transform.position.z)){
					standingPosition = new Vector3(transform.position.x, transform.position.y, obj.transform.position.z + 1.0f * Mathf.Sign(transform.position.z - obj.transform.position.z));
				} else {
					standingPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
				}
			}
		}
		if(!fightFlag) {
			stateChange(State.walk);
		}
		if(aloneFlag) {
			standingPosition = new Vector3(transform.position.x, transform.position.y, 0.0f);
		}
	}
	
	override protected void InitStateEat() {
		SendMessage("PlaySoundSingle", 4, SendMessageOptions.DontRequireReceiver);
	}
	
	override protected void PlayStateEat() {
		ModifyPosition();
		
		bool eatFlag = false;
		Collider[] colliders = Physics.OverlapSphere(transform.position, fightRadius);
		foreach (Collider obj in colliders) {
			if((obj) && (obj.tag == "Food")) {
				eatFlag = true;
				SendMessage("LevelUp", 1, SendMessageOptions.DontRequireReceiver);
				obj.transform.SendMessage("Eaten", SendMessageOptions.DontRequireReceiver);
			}
		}
		if(!eatFlag) {
			stateChange(State.walk);
		}
	}
	
	override protected void InitStateDead() {
		rigidbody.AddForceAtPosition(deadForceDirection, deadForcePosition);
		Destroy(gameObject, deathTimer);
	}
	
	void DominateBase(Transform argBase, float damage) {
		Base baseComponent = argBase.GetComponent<Base>();
		baseComponent.Dominated(damage, transform.tag);
	}
	
	void LevelUp(int num) {
		attackDamage += 0.5f * num;
		transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
	}
}
