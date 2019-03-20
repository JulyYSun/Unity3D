using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirControl : MonoBehaviour {
	private Transform m_transform;
	public float autorotateSpeed=10.0f;
	public float rotateSpeed_AxisX=40.0f;
	public float speed = 600f;
	private float rotationz=0.0f;
	private float rotationx=0.0f;
	public float rotateSpeed_AxisZ=45f;
	public float rotateSpeed_AxisY=20f;
	private Vector2 touchPosition;
	private float screenWeight;

	// Use this for initialization
	void Start () {
		m_transform = this.transform;
		screenWeight = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		rotationz = this.transform.eulerAngles.z;
		rotationx = this.transform.eulerAngles.x;
		m_transform.Translate (0, 0, speed * Time.deltaTime);
		GameObject.Find ("propeller").transform.Rotate (0, 1000f * Time.deltaTime, 0);
		/*if (rotationx >= -85 && rotationx<=175) {
			m_transform.transform.Rotate (Time.deltaTime * autorotateSpeed, 0, 0);
		}*/
		if (Input.touchCount > 0) {
			for(int i=0;i<Input.touchCount;i++){
				Touch touch = Input.touches [i];
				if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) {
					touchPosition = touch.position;
					if (touchPosition.x < screenWeight / 2) {
						//相当于绕着自身旋转
						m_transform.Rotate (0, 0, rotateSpeed_AxisZ * Time.deltaTime, Space.Self);
						//世界方位的旋转
						m_transform.Rotate (0, -30 * Time.deltaTime, 0, Space.World);
					} else if (touchPosition.x >= screenWeight / 2) {
						m_transform.Rotate (0, 0, -rotateSpeed_AxisY * Time.deltaTime, Space.Self);
						m_transform.Rotate (0, 30 * Time.deltaTime, 0, Space.World);
					}
				} else if (touch.phase == TouchPhase.Ended) {
					BackToBalance ();
				}
						
						



		}
			}
		if (Input.touchCount == 0) {
			BackToBalance ();
		}

		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				Application.Quit ();
			}

		}
		}








		/*
		//向左转向的同时还要向左倾斜
		if (Input.GetKey (KeyCode.A)) {
			//相当于绕着自身旋转
			m_transform.Rotate (0, 0,rotateSpeed_AxisZ * Time.deltaTime,Space.Self);
			//世界方位的旋转
			m_transform.Rotate (0,-30*Time.deltaTime,0,Space.World);
		}
		if (Input.GetKey (KeyCode.D)) {
			m_transform.Rotate (0, 0, -rotateSpeed_AxisY * Time.deltaTime, Space.Self);
			m_transform.Rotate (0, 30*Time.deltaTime,0,Space.World);
		}
		if (Input.GetKey (KeyCode.W)) {
			m_transform.transform.Rotate (-Time.deltaTime * rotateSpeed_AxisX, 0, 0,Space.Self);
		}
		BackToBalance ();
	*/


	void BackToBalance(){
		if (rotationz <= 180) {
			if (rotationz <= 2) {
				m_transform.transform.Rotate (0, 0, Time.deltaTime * -1);
			} else {
				m_transform.transform.Rotate (0, 0, Time.deltaTime * -40);

			}
		}
		if (rotationz > 180) {
			if (360-rotationz <= 2) {
				m_transform.transform.Rotate (0, 0, Time.deltaTime * 1);
			} else {
				m_transform.transform.Rotate (0, 0, Time.deltaTime * 40);

			}
		}
	}
}
