using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	GameObject[] friendlyObjects;
	GameObject[] enemyObjects;
	GameObject spawners;
	
	enum State {
		NOCHANGE  = -1, title = 0, playing, gameover
	}
	State state;
	State stateChanger;

	// Use this for initialization
	void Start () {
		ChangeState(State.title);
	}
	
	// Update is called once per frame
	void Update () {
		if(stateChanger != State.NOCHANGE) {
			InitState(stateChanger);
			stateChanger = State.NOCHANGE;
		}
		PlayState(state);
	}
	
	void InitState (State argState) {
		switch(argState) {
		case State.title:
			InitTitleScreen();
			break;
		case State.playing:
			InitPlaying();
			break;
		case State.gameover:
			InitGameOver();
			break;
		default:
			break;
		}
	}
	
	void PlayState (State argState) {
		switch(argState) {
		case State.title:
			PlayTitleScreen();
			break;
		case State.playing:
			PlayPlaying();
			break;
		case State.gameover:
			PlayGameOver();
			break;
		default:
			break;
		}
	}
	
	void InitTitleScreen () {
		friendlyObjects = GameObject.FindGameObjectsWithTag("Friendly");
		foreach(GameObject obj in friendlyObjects) {
			obj.SetActive(false);
		}
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject obj in enemyObjects) {
			obj.SetActive(false);
		}
		spawners = GameObject.Find("Spawner");
		spawners.SetActive(false);
		
		
	}
	
	void PlayTitleScreen () {
		if (Input.GetButtonDown("Fire1")) {
			ChangeState(State.playing);
		}
	}
	
	void InitPlaying () {
		foreach(GameObject obj in friendlyObjects) {
			obj.SetActive(true);
		}
		foreach(GameObject obj in enemyObjects) {
			obj.SetActive(true);
		}
		spawners.SetActive(true);
	}
	
	void PlayPlaying () {
		
	}
	
	void InitGameOver () {
		
	}
	
	void PlayGameOver () {
		
	}
	
	void ChangeState (State argState) {
		state = argState;
		stateChanger = argState;
	}
	
	void GameOver () {
		ChangeState(State.gameover);
	}
}
