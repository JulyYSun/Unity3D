using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class twopins2 : MonoBehaviour {

	Rigidbody2D rg;
	public int speed;
	public bool move=true;
	public Circle circle;
	public bool gameisover = false;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		circle = GameObject.Find ("circle2").GetComponent<Circle> ();
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
			if (circle.speed <= -30) {
				circle.speed += 6f;
			}


		}
		if (collision.gameObject.tag == "pin") {
			Camera.main.backgroundColor = Color.red;
			StartCoroutine (Restart ());
			move = false;
			circle.speed = -200f;
			GameObject.Find ("point2").GetComponent<Createpin> ().enabled = false;
		}
	}
	IEnumerator Restart(){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
