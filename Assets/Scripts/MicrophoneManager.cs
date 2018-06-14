using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
[DisallowMultipleComponent]	
public class MicrophoneManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		foreach (string device in Microphone.devices) {
            Debug.Log("Name: " + device);
        }
		var audio = GetComponent<AudioSource>();
		audio.clip = Microphone.Start("Soundflower (2ch)", true, 10, 44100);
		audio.loop = true;
        while (Microphone.GetPosition(null) <= 0) {}
		audio.Play();
	}
}
