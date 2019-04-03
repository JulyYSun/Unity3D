using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{

	private bool isMoveLeft = false;  //是否向左移动
	private bool isJumping = false;  //玩家是否正在移动
	private Vector3 nextPlatformLeft;
	private Vector3 nextPlatformRight;
	private ManagerVars vars;

	private void Awake()
	{
		vars=ManagerVars.GetManagerVars();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.Instance.isGameOver || GameManager.Instance.isGameStarted==false)
			return;
		if (Input.GetMouseButtonDown(0) && !isJumping)  //点击屏幕且玩家没有跳跃时
		{
			Vector3 mousePos = Input.mousePosition;
			EventCenter.Broadcast(EventDefine.DecidePath);  //广播生成平台事件，生成平台监听到消息后生成下一个平台
			//判断点击
			if (mousePos.x <= Screen.width / 2)
			{
				isMoveLeft = true;
			}
			else if (mousePos.x >= Screen.width / 2)
			{
				isMoveLeft = false;
			}
			Jump();
		}
		
	}

	private void Jump()
	{
		isJumping = true;  //玩家跳跃时，将正在跳跃变为true
		if (isMoveLeft)
		{
			transform.localScale=new Vector3(-1,1,0);  //向左跳跃角色需要翻转身体
			transform.DOMoveX(nextPlatformLeft.x, 0.2f);
			transform.DOMoveY(nextPlatformLeft.y + 0.8f, 0.15f);
		}
		else
		{
			transform.localScale=Vector3.one;
			transform.DOMoveX(nextPlatformRight.x, 0.2f);
			transform.DOMoveY(nextPlatformRight.y + 0.8f, 0.15f);
		}
		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Platform")
		{
			isJumping = false;  //碰到平台后才可以进行下一次跳跃
			Vector3 currentPlatformPos = other.gameObject.transform.position;
			nextPlatformLeft=new Vector3(currentPlatformPos.x-vars.nextXPos,
				currentPlatformPos.y+vars.nextYPos,0);
			nextPlatformRight=new Vector3(currentPlatformPos.x+vars.nextXPos,
				currentPlatformPos.y+vars.nextYPos,0);
		}
	}
}














