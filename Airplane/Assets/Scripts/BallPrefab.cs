using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour {
	public int i = 5;
	public int j = 0;
	public Rigidbody ballPrefab;
	public float x = 0.0f;
	public float y = 4.0f;
	public float z = 0.0f;
	public float k = 2.0f;
	public int n = 4;
	public Rigidbody[] bP;//预制体数组
	int count=0;
	// Use this for initialization
	void Start () {
		bP = new Rigidbody[10];
		count = 0;
		for (i = 0; i < n; i++) {
			//生成预制体，instantiate方法
			for (j = 0; j < i; j++) {
				bP [count++] = (Rigidbody)Instantiate (ballPrefab,
					new Vector3 (x - 2.0f * k * i + 4.0f * j * k, 2.0f, z - 2.0f * 1.75f * k * i), ballPrefab.rotation);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
