using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	public GameObject AsteroidExplosion;
	public GameObject PlayerExplosion;
	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Player") {
			Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
		}

		Instantiate(AsteroidExplosion, transform.position, transform.rotation);
		DestroyObject(other.gameObject);
		DestroyObject(gameObject);
	}
}
