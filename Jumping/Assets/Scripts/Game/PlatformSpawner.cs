using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

	public Vector3 startSpawnPos;  //平台起始的位置

	private int spawnPlatformCount;  //每次生成平台的数量，初始化时为5，之后为1到4的随机数
	private Vector3 platformSpawnPos;  //下一个平台生成的位置
	
	//是向左还是向右生成平台
	private bool isLeftSpawn = false;
	private ManagerVars vars;
	// Use this for initialization
	private void Awake()
	{
		//监听生成平台事件，如果有该事件，则执行DecidePath方法
		EventCenter.AddListener(EventDefine.DecidePath,DecidePath);
	}

	private void OnDestroy()
	{
		EventCenter.RemoveListener(EventDefine.DecidePath,DecidePath);
	}

	void Start ()
	{
		platformSpawnPos = startSpawnPos;
		vars=ManagerVars.GetManagerVars();
		//初始化时生成五个向右的平台
		for (int i = 0; i < 5; i++)
		{
			spawnPlatformCount = 5;
			DecidePath();
		}
		
		//生成玩家
		GameObject go = Instantiate(vars.characterPre,transform);
		go.transform.position=new Vector3(0,-1.8f,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//平台方向选择
	private void DecidePath()
	{
		if (spawnPlatformCount > 0)
		{
			spawnPlatformCount--;
			SpawnPlatform();
		}
		else
		{
			isLeftSpawn = !isLeftSpawn;
			spawnPlatformCount = Random.Range(1, 4);
			SpawnPlatform();
		}
	}

	//生成平台，下一个平台是在上一个平台的基础上加上相应偏移量
	private void SpawnPlatform()
	{
		SpawnNormalPlatform();
		if (isLeftSpawn)  //向左生成
		{
			platformSpawnPos=new Vector3(platformSpawnPos.x-vars.nextXPos,
				platformSpawnPos.y+vars.nextYPos,0);
		}
		else  //向右生成
		{
			platformSpawnPos=new Vector3(platformSpawnPos.x+vars.nextXPos,
				platformSpawnPos.y+vars.nextYPos,0);
		}
	}

	//生成普通的平台
	private void SpawnNormalPlatform()
	{
		GameObject go = Instantiate(vars.normalPlatformPre,transform);
		go.transform.position = platformSpawnPos;
	}
}












