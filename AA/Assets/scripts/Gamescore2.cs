using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gamescore2 : MonoBehaviour {
	public static int score = 0;
	public int maxscore=0;
	public int nowscore=0;
	public Text scoretext;
	public Text tip;
	public Text maxtip;
	public Text maxscoretxt;
	// Use this for initialization
	void Start () {
		score = 0;

	}
	void addmax(){
		maxtip.text = "打破记录！";
		PlayerPrefs.SetInt("maxscore2", nowscore);
		PlayerPrefs.Save ();
	}
	// Update is called once per frame
	void Update () {
		scoretext.text = score + "";
		if(PlayerPrefs.HasKey("maxscore2")){
			maxscore=PlayerPrefs.GetInt("maxscore2");
		}
		maxscoretxt.text = "  历史记录: " + maxscore;
		if (score > maxscore) {
			nowscore = score;
			addmax ();
		}
		if (score == 30) {
			tip.text = "即将达到最慢速度！";
		}
		if (score == 31) {
			tip.text = "";
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");
		}
	}
}