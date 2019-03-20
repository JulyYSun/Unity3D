using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointmove : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		this.transform.position=new Vector2 ((float)0.8*Mathf.Sin(0.6f*Time.time), -3.5f);




	}
}
