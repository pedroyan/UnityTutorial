using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	Rigidbody rb;
	public float Tumble;
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere*Tumble;
	}
}
