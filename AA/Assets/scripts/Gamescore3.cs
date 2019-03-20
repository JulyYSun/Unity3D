using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamescore3 : MonoBehaviour {

	public static int score = 0;
	public int maxscore=0;
	public int nowscore=0;
	public Text scoretext;
	public Text maxtip;
	public Text maxscoretxt;
	// Use this for initialization
	void Start () {
		score = 0;

	}
	void addmax(){
		maxtip.text = "打破记录！";
		PlayerPrefs.SetInt("maxscore3", nowscore);
		PlayerPrefs.Save ();
	}
	// Update is called once per frame
	void Update () {
		scoretext.text ="当前得分："+score;
		if(PlayerPrefs.HasKey("maxscore3")){
			maxscore=PlayerPrefs.GetInt("maxscore3");
		}
		maxscoretxt.text = "历史记录: " + maxscore;
		if (score > maxscore) {
			nowscore = score;
			addmax ();
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}
}
}
