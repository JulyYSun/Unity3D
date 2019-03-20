using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sin_Pin : MonoBehaviour {
	Rigidbody2D rg;
	public int speed=12;
	public bool move=true;
	public sin_rotate circle;
	public bool gameisover = false;
	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody2D> ();
		circle = GameObject.Find("circle").GetComponent<sin_rotate> ();

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
			sinGamescore.score += 1;

			if (circle.addspeed>= 80) {
				circle.addspeed -= 6;
			}




		}
		if (collision.gameObject.tag == "pin") {
			Camera.main.backgroundColor = Color.red;
			StartCoroutine (Restart ());
			move = false;
			circle.addspeed = 500;
			GameObject.Find ("createpoint").GetComponent<Createpin> ().enabled = false;
		}
	}
	IEnumerator Restart(){
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
