using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
[DisallowMultipleComponent]	
public class SpectrumAnalyzer : MonoBehaviour {
	public int resolution = 1024;
    public float lowFreqThreshold = 14700, midFreqThreshold = 29400, highFreqThreshold = 44100;
    public float lowEnhance = 1f, midEnhance = 10f, highEnhance = 100f;
	private AudioSource audio_;
	private float low = 0f, mid = 0f, high = 0f;
	

	// Use this for initialization
	void Start(){
        audio_ = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		//フーリエ変換
		var spectrum = audio_.GetSpectrumData(1024, 0, FFTWindow.Hamming);
		var deltaFreq = AudioSettings.outputSampleRate / resolution;
		
		//値の初期化
		low = 0f;
		mid = 0f;
		high = 0f;

		for (var i = 0; i < resolution; ++i) {
            var freq = deltaFreq * i;
            if      (freq <= lowFreqThreshold)  low  += spectrum[i];
            else if (freq <= midFreqThreshold)  mid  += spectrum[i];
            else if (freq <= highFreqThreshold) high += spectrum[i];
        }

        low  *= lowEnhance;
        mid  *= midEnhance;
        high *= highEnhance;
	}

	public float getLow (){
		return low;
	}
	
	public float getMid (){
		return mid;
	}
	
	public float getHigh (){
		return high;
	}
}
