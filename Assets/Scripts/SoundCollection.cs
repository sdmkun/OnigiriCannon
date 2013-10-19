using UnityEngine;
using System.Collections;

public class SoundCollection : MonoBehaviour {
	
	public AudioClip[] audioClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public AudioClip GetAudioClip(int num) {
		return audioClip[num];
	}
}
