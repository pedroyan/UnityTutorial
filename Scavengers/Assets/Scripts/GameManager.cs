﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
	private int level = 3;                                  //Current level number, expressed in game as "Day 1".

	//Awake is always called before any Start functions
	void Awake() {
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		boardScript = GetComponent<BoardManager>();

		InitGame();
	}

	//Initializes the game for each level.
	void InitGame() {
		boardScript.SetupScene(level);
	}

	//Update is called every frame.
	void Update() {

	}
}