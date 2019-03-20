using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sin_rotate : MonoBehaviour {
	public float speed;
	public int addspeed=200;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		speed = addspeed*Mathf.Sin (Time.time*0.8f );
		this.transform.Rotate (0, 0, speed * Time.deltaTime);
	}
}
