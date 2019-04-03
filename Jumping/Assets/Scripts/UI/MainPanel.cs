using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanel : MonoBehaviour {

	private Button btn_Start;
	private Button btn_Shop;
	private Button btn_Rank;
	private Button btn_Sound;
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		Init ();
	}
	// Update is called once per frame
	void Update () {
		
	}
	private void Init(){
		btn_Start = transform.Find ("btn_Start").GetComponent<Button> ();
		//在脚本里给按钮添加监听事件，可以不用在Unity Editor下面添加监听,当然，我是在Unity里面添加的监听。。。
		//btn_Start.onClick.AddListener (OnStartButtonClick);
		btn_Shop = transform.Find ("Btns/btn_Shop").GetComponent<Button> ();

		btn_Rank = transform.Find ("Btns/btn_Rank").GetComponent<Button> ();
		btn_Sound = transform.Find ("Btns/btn_Sound").GetComponent<Button> ();
	}

	//Button点击事件处理函数
	public void OnStartButtonClick()
	{
		GameManager.Instance.isGameStarted = true;
		EventCenter.Broadcast (EventDefine.ShowGamePanel);
		gameObject.SetActive (false);
	}
	public void OnShopButtonClick(){

	}
	public void OnRankButtonClick(){

	}
	public void OnSoundButtonClick(){

	}
}
