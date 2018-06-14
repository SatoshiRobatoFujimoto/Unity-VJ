using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	SpectrumAnalyzer spectrum;

	// Use this for initialization
	void Start () {
		spectrum = GameObject.Find("Audio Source").GetComponent<SpectrumAnalyzer>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3(spectrum.getHigh() * 5 + 2, spectrum.getMid() * 5 + 2, spectrum.getLow() * 5 + 2);
	}
}
