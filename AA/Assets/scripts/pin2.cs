
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pin2 : MonoBehaviour {
	Rigidbody2D rg;
	public int speed=12;
	public bool move=true;
	public Circle circle1;
	public bool gameisover = false;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		circle1 = GameObject.FindGameObjectWithTag ("circle").GetComponent<Circle> ();


	}

	// Update is called once per frame
	void Update () {
		if (move) {
			rg.MovePosition (rg.position + Vector2.up * speed * Time.deltaTime);
			//rg.velocity=new Vector3(0f,2f);
		}

	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "circle") {
			this.transform.SetParent (collision.gameObject.transform);
			move = false;
			Gamescore2.score += 1;
			if (circle1.speed >= 10) {
				circle1.speed -= 2.5f;
			}



		}
		if (collision.gameObject.tag == "pin") {
			Camera.main.backgroundColor = Color.red;
			StartCoroutine (Restart ());
			move = false;
			circle1.speed = 200f;
			GameObject.Find ("createpoint").GetComponent<Createpin> ().enabled = false;
		}
	}
	IEnumerator Restart(){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
