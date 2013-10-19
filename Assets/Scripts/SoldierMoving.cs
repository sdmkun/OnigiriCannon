using UnityEngine;
using System.Collections;

public class SoldierMoving : MonoBehaviour {
	
	//状態遷移の状態を示す定数
	protected enum State {
		NOCHANGE = -1, stop = 0, walk, fight, eat, dead
	}
	//状態遷移管理変数
	protected State state = State.stop;
	//状態遷移した瞬間の初期化用
	protected State stateChanger = State.NOCHANGE;
	
	public float moveForce;
	public float maxSpeed;
	public float fracJourney;
	public int deathTimer;
	
	protected bool onSurface;
	
	protected Vector3 standingPosition = new Vector3(0, 0.43f, 0);
	protected Quaternion standingRotation = Quaternion.Euler(new Vector3(0, 0, 0));
	protected Vector3 deadForceDirection = new Vector3(0, 0, 200);
	protected Vector3 deadForcePosition = new Vector3(0.0f, -0.4f, 0.0f);
	
	protected float fightRadius = 1.7f;
	protected float startTime;
	
	// Use this for initialization
	protected void Start () {
		startTime = Time.time;
		state = State.walk;
	}
	
	// Update is called once per frame
	protected void Update () {
		if(stateChanger != State.NOCHANGE) {
			InitState (stateChanger);
			stateChanger = State.NOCHANGE;
		}
		PlayState(state);
	
	}
	
	protected void InitState(State state) {
		switch(state) {
		case State.stop:
			InitStateStop();
			break;
		case State.walk:
			InitStateWalk();
			break;
		case State.fight:
			InitStateFight();
			break;
		case State.eat:
			InitStateEat();
			break;
		case State.dead:
			InitStateDead();
			break;
		default:
			break;
		}
	}
	
	protected void PlayState(State state) {
		switch(state) {
		case State.stop:
			PlayStateStop();
			break;
		case State.walk:
			PlayStateWalk();
			break;
		case State.fight:
			PlayStateFight();
			break;
		case State.eat:
			PlayStateEat();
			break;
		case State.dead:
			PlayStateDead();
			break;
		default:
			break;
		}
	}
	
	virtual protected void InitStateStop() {
		
	}
	
	virtual protected void PlayStateStop() {
		
	}
	
	virtual protected void InitStateWalk() {
		
	}
	
	virtual protected void PlayStateWalk() {
		
	}
	
	virtual protected void InitStateFight() {
		
	}
	
	virtual protected void PlayStateFight() {
		
	}
	
	virtual protected void InitStateEat() {
		
	}
	
	virtual protected void PlayStateEat() {
		
	}
	
	virtual protected void InitStateDead() {
		
	}
	
	virtual protected void PlayStateDead() {
		
	}
	
	protected void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Surface") {
			onSurface = true;
		}
	}
	
	protected void OnCollisionExit(Collision collision) {
		if(collision.gameObject.tag == "Surface") {
			onSurface = false;
		}
	}
	
	protected void Die() {
		stateChange(State.dead);
		gameObject.tag = "Untagged";
	}
	
	protected void stateChange(State argState) {
		state = argState;
		stateChanger = argState;
	}
	
	protected void ModifyPosition() {
		standingPosition.x = transform.position.x;
		standingPosition.y = transform.position.y;
		transform.position = Vector3.Lerp(transform.position, standingPosition, 5 * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, standingRotation, 20 * Time.deltaTime);
	}
	
}
