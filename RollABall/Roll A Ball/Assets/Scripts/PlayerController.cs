using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public int VictoryCount;
	public Text countText;
	public Text WinText;

	private Rigidbody rb;
	private int count;

	/// <summary>
	/// Called in First frame the script is acting
	/// </summary>
	private void Start() {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText();
		WinText.text = "";
	}

	/// <summary>
	/// Called before rendering a frame
	/// </summary>
	private void Update() {
		
	}

	/// <summary>
	/// Called before performing any physics calculations
	/// </summary>
	private void FixedUpdate() {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal,0,moveVertical);

		rb.AddForce(movement * speed);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
		if (count == VictoryCount) {
			WinText.text = "You Win!";
		}
	}
}