using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gui : MonoBehaviour {
	public GUISkin[] gskin;
	public int skin_index = 0;

	// Use this for initialization
	void Start () {
		
	}
	void OnGUI(){
		GUI.backgroundColor = Color.cyan;
		if(GUI.Button(new Rect(50,50,100,100),"a button")){
			Debug.Log ("pressed!");
		}

	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			GUI.backgroundColor = Color.cyan;

		}
	}
}
