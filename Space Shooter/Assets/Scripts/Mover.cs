﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
		var rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * Speed;
	}
}
