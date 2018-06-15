using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour {
	public int MaxChild = 100;
	public GameObject BoidsChild;
	public GameObject[] BoidsChildren;

	public GameObject BoidsBoss;
	public GameObject BoidsCenter;

	public float Turbulence = 1f;

	public float Distance = 2;

	SpectrumAnalyzer spectrum;
	

	// Use this for initialization
	void Start () {
		spectrum = GameObject.Find("Audio Source").GetComponent<SpectrumAnalyzer>();

		this.BoidsChildren = new GameObject[MaxChild];
		for (int i = 0; i < this.MaxChild; i++) {
        	this.BoidsChildren[i] = GameObject.Instantiate(BoidsChild) as GameObject;
 
        	this.BoidsChildren[i].transform.position = new Vector3(
				Random.Range(-30f, 30f),
				Random.Range(-10f, 60f),
				Random.Range(-30f, 0f)
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateBoss();
		Vector3 center = getCenter();

		//中央に移動しようとする
		foreach (GameObject child in this.BoidsChildren) {	
			Vector3 dirToCenter = (center - child.transform.position).normalized;

			Rigidbody rigibody = child.GetComponent<Rigidbody>();
			Vector3 direction = (rigibody.velocity.normalized * this.Turbulence + dirToCenter * (1 - this.Turbulence)).normalized;
			direction *= spectrum.getLow() * 30f;
			rigibody.velocity = direction;
		}

		//距離を保つ
		foreach (GameObject child_a in this.BoidsChildren) {	
			foreach (GameObject child_b in this.BoidsChildren) {	
				Rigidbody rigibody_a = child_a.GetComponent<Rigidbody>();
				Rigidbody rigibody_b = child_b.GetComponent<Rigidbody>();
				if (child_a == child_b) continue;
				Vector3 diff = child_a.transform.position - child_b.transform.position;
				if (diff.magnitude < Random.Range(0, this.Distance)){
					rigibody_a.velocity = diff.normalized * rigibody_a.velocity.magnitude;
		        }
			}
		}

		Vector3 averageVelocity = Vector3.zero;
 
		foreach (GameObject child in this.BoidsChildren) {
			averageVelocity += child.GetComponent<Rigidbody>().velocity;
		}
		
		averageVelocity /= this.BoidsChildren.Length;
		
		foreach (GameObject child in this.BoidsChildren) {
			Rigidbody rigibody = child.GetComponent<Rigidbody>();
			rigibody.velocity = rigibody.velocity * this.Turbulence + averageVelocity * (1f - this.Turbulence);
			child.transform.LookAt(center);
			child.transform.localScale = new Vector3(spectrum.getLow() * 1f + 0.2f, spectrum.getLow() * 1f + 0.2f, spectrum.getLow() * 1f + 0.2f);
		}
	}

	private void updateBoss(){
		this.BoidsBoss.transform.position = new Vector3(
			Mathf.Cos(Time.time * 2.3f) * 3f,
			Mathf.Sin(Time.time) * 1f + 2f,
			0
		);
	}

	private Vector3 getCenter(){
		Vector3 center = Vector3.zero;
		foreach (GameObject child in this.BoidsChildren) {
			center += child.transform.position;
		}
		center /= (BoidsChildren.Length - 1);
		center += this.BoidsBoss.transform.position;
		center /= 2;
		this.BoidsCenter.transform.position = center;
		return center;
	}
}
