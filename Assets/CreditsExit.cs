﻿using UnityEngine;
using System.Collections;

public class CreditsExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") || Input.GetKey("joystick button 5"))
            Application.LoadLevel("MainMenu");
	}
}
