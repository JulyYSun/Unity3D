using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTheme : MonoBehaviour
{
	private SpriteRenderer m_SpriteRenderer;
	private ManagerVars vars;
	private void Awake()
	{
		vars=ManagerVars.GetManagerVars();
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		int ranValue = Random.Range(0, vars.BgThemeSpriteList.Count);
		m_SpriteRenderer.sprite = vars.BgThemeSpriteList[ranValue];
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
