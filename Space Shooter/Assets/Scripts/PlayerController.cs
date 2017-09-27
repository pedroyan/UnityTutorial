using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Boundaries {
	public float MaxValue;
	public float MinValue;
}

public class PlayerController : MonoBehaviour {

	public float Speed;
	public float MaxModX;
	public float horizontalTilt;
	public float verticalTilt;

	public Boundaries zBoundaries;

	public GameObject Bolt;
	public Transform BoltSpawn;
	public float Cooldown = 0.5f;

	float nextFire = 0.0f;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			var rot = new Quaternion(0,BoltSpawn.rotation.y,BoltSpawn.rotation.z,BoltSpawn.rotation.w);
			var spawn = new Vector3(BoltSpawn.position.x, 0, BoltSpawn.position.z);
			Instantiate(Bolt,spawn,rot);
			nextFire = Time.time + Cooldown;
		}
	}

	private void FixedUpdate() {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0, moveVertical);

		rb.velocity = movement * Speed;
		rb.position = new Vector3(Mathf.Clamp(rb.position.x, -MaxModX, MaxModX), 0, Mathf.Clamp(rb.position.z, zBoundaries.MinValue, zBoundaries.MaxValue));
		rb.rotation = Quaternion.Euler(new Vector3(rb.velocity.z* verticalTilt, 0, -rb.velocity.x * horizontalTilt));
	}
}
