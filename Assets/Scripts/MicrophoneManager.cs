using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
[DisallowMultipleComponent]	
public class MicrophoneManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		var audio = GetComponent<AudioSource>();
		audio.clip = Microphone.Start(null, true, 10, 44100);
		audio.loop = true;
        while (Microphone.GetPosition(null) <= 0) {}
		audio.Play();
	}
}
