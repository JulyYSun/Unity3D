﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createpin : MonoBehaviour {
	public GameObject pin;
	public Transform point;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate (pin,point);
		}
	}
}
