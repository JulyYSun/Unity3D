using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateManagerVars")]
public class ManagerVars : ScriptableObject
{
	public static ManagerVars GetManagerVars()
	{
		return Resources.Load<ManagerVars>("ManagerVarsContainer");
	}
	public List<Sprite> BgThemeSpriteList;  //背景列表

	public float nextXPos = 0.554f, nextYPos = 0.645f;  //下一个平台的偏移量

	public GameObject normalPlatformPre;  //平台预制体

	public GameObject characterPre;  //玩家预制体
	// Use this for initialization
	void Start () {
		   
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
