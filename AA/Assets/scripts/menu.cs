using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour {

	public void normalgame(){
		SceneManager.LoadScene ("01");
	}
	public void crazygame(){
		SceneManager.LoadScene ("02");
	}
	public void crazygame2(){
		SceneManager.LoadScene ("03");
	}
	public void crazygame3(){
		SceneManager.LoadScene ("04");
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
