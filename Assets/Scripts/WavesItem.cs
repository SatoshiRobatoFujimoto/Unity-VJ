using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesItem : MonoBehaviour {
    SpectrumAnalyzer spectrum;
    float scale = 0;
	void Start () {
        spectrum = GameObject.Find("Audio Source").GetComponent<SpectrumAnalyzer>();
        this.transform.localScale = new Vector3(0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
        if (!GetComponent<Renderer>().isVisible) {
            Destroy(this.gameObject);
        }
        scale += Time.deltaTime * 2;
        this.transform.localScale = new Vector3(
            scale * spectrum.getLow(),
            scale * spectrum.getLow(),
            scale * spectrum.getLow() * spectrum.getLow() * 0.1f);

        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            this.transform.position.z - 0.2f
        );

        this.transform.localRotation = Quaternion.Euler(
            0,
            Time.time * 40,
            Time.time * 50
        );
	}
}
