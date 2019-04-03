using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	private Transform target;

	private Vector3 offset;

	private Vector2 velocity;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null && GameObject.FindGameObjectWithTag("Player") != null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}

	private void FixedUpdate()
	{
		if (target!=null)
		{
			float posX=Mathf.SmoothDamp(transform.position.x, target.position.x - offset.x, ref velocity.x, 0.05f);
			float posY=Mathf.SmoothDamp(transform.position.y, target.position.y - offset.y, ref velocity.y, 0.05f);
			if(posY>transform.position.y)  //只有玩家向上移动的时候摄像机跟随
				transform.position=new Vector3(posX,posY,transform.position.z);
		}
	}
}
