using UnityEngine;
using System.Collections;

public class FrameCounter : MonoBehaviour {
	
	int frame = 0;
	
	// Use this for initialization
	void Start () {
		frame = 0;
	}
	
	// Update is called once per frame
	void Update () {
		++frame;
	}
	
	public int GetFrame() {
		return frame;
	}
}
