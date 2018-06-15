using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class GlobalManager : MonoBehaviour {
	public bool isDebug = false;
	public float speed = 0.5f;
	public float waveRadius = 0;
	public float boidsTurbulence = 1f;
	public float boidsDistance = 0;


	// Use this for initialization
	void Start () {
		MidiMaster.knobDelegate += Knob;
	}

	void Knob(MidiChannel channel, int knobNumber, float knobValue) {
    	if(isDebug) Debug.Log("Knob: " + knobNumber + "," + knobValue);
		if(knobNumber == 6) {
			setWaveRadius(knobValue);
		}
		if(knobNumber == 7) {
			setBoidsTurbulence(knobValue);
		}
		if(knobNumber == 23) {
			setBoidsDistance(knobValue);
		}
    }

	public void setWaveRadius (float val){
			waveRadius = val * 8f + 1f;
	}

	public void setBoidsTurbulence (float val){
			boidsTurbulence = val;
	}

	public void setBoidsDistance (float val){
			boidsDistance = val * 100;
	}


	public float getSpeed () {
		return speed;
	}

	public void setSpeed (float _speed) {
		speed = _speed;
	}
}
