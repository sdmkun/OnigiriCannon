using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	SoundCollection soundCollection;
	AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find("SoundCollection");
		soundCollection = (SoundCollection)obj.GetComponent("SoundCollection");
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void PlaySound (int num) {
		if(soundCollection.GetAudioClip(num)) {
			audioSource.clip = soundCollection.GetAudioClip(num);
		}
		audioSource.PlayOneShot(audioSource.clip);
	}
	
	void PlaySoundSingle (int num) {
		if(soundCollection.GetAudioClip(num)) {
			audioSource.clip = soundCollection.GetAudioClip(num);
		}
		if(!audioSource.isPlaying) {
			audioSource.Play();
		}
	}
}
