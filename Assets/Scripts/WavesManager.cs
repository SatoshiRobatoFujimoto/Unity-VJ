using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesManager : MonoBehaviour {
	GlobalManager global;
	public GameObject plane;

	public float startAngle = 0;

	private float time = 0;

	private float radius = 7f;

	private Vector3 position;

	// Use this for initialization
	void Start () {
		global = GameObject.Find("GlobalManager").GetComponent<GlobalManager>();
	}

	// Update is called once per frame
	void Update () {
		position = getPosition();
		time += Time.deltaTime;

		if(time > 0.1f) {
			GameObject item = Instantiate(plane, position, Quaternion.identity);
			time = time - 0.1f;
		}
	}

	Vector3 getPosition(){
		radius += (global.waveRadius - radius) * 0.05f;
		float time = Time.time * global.speed * 2 + (startAngle / 180 * Mathf.PI);
		return new Vector3(
			(Mathf.Cos(time + 2.4f) + Mathf.Cos(time + 1.2f) + Mathf.Cos(time + 0.8f)) / 3f * radius + 2f,
			(Mathf.Sin(time + 2.4f) + Mathf.Sin(time + 1.2f) + Mathf.Sin(time + 0.8f)) / 3f * radius + 2f,
			Mathf.Cos(time) * 10f + 8f
		);
	}
}
