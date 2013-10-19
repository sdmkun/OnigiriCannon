using UnityEngine;
using System.Collections;

public class EndApplication : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey(KeyCode.Escape) ){
			Application.Quit();
		}
	}
}
