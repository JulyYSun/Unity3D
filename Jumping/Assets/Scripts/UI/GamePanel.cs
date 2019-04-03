using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GamePanel : MonoBehaviour {
	private Button btn_Pause;
	private Button btn_Play;
	private Text txt_Score;
	private Text txt_Diamond;
	// Use this for initialization
	

	void Start () {
		
	}

	private void Awake()
	{
		Init();
	}

	public void Init()
	{
		EventCenter.AddListener (EventDefine.ShowGamePanel, Show);
		//获取组件
		btn_Pause = transform.Find ("btn_Pause").GetComponent<Button> ();
		btn_Play = transform.Find ("btn_Play").GetComponent<Button> ();
		btn_Play.gameObject.SetActive(false);
		txt_Score = transform.Find ("txt_Score").GetComponent<Text> ();
		txt_Diamond = transform.Find ("Diamond/txt_Diamond").GetComponent<Text> ();
		//游戏初始化时游戏面板不可见
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDestroy(){
		EventCenter.RemoveListener (EventDefine.ShowGamePanel, Show);
	}
	void Show(){
		gameObject.SetActive (true);
	}

	//暂停按钮点击
	public void OnPauseButtonClick()
	{
		btn_Pause.gameObject.SetActive(false);
		btn_Play.gameObject.SetActive(true);
		//todo
		//游戏暂停
	}

	//游戏继续按钮
	public void OnPlayButtonClick()
	{
		btn_Pause.gameObject.SetActive(true);
		btn_Play.gameObject.SetActive(false);
		//todo
		//游戏继续
	}
}
