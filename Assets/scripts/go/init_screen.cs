using UnityEngine;
using KBEngine;
using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;

public class init_screen : MonoBehaviour {
	
	public static UITexture obj;
	public static init_screen inst = null;
	bool isShowLogo = true;
	bool isClosed = false;
	
	void Awake ()     
	{
		obj = GetComponent<UITexture>();
		loadingbar_backgroundpic.Transparent_Colored = Shader.Find("Unlit/Transparent Colored");
		obj.shader = loadingbar_backgroundpic.Transparent_Colored;
		inst = this;
	}
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("show_logo", 2f, 0.1f);
		
		UnityEngine.GameObject.Find("init_logo").GetComponent<UITexture>().shader = loadingbar_backgroundpic.Transparent_Colored;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void show_logo()
	{
		CancelInvoke("show_logo");
		isShowLogo = false;
		
		if(isClosed == true)
			close_screen();
	}
	
	public void close_screen()
	{
		isClosed = true;
		if(isShowLogo == true)
			return;
		
		CancelInvoke("close_screen");
		Color c = obj.color;
		c.a -= 0.05f;
		obj.color = c;
		if(obj.color.a <= 0.0f)
		{
			obj = null;
			inst = null;
			Destroy(UnityEngine.GameObject.Find("init_screen"));
			return;
		}
		else if(obj.color.a <= 0.8f)
		{
			if(UnityEngine.GameObject.Find("init_logo") != null)
				Destroy(UnityEngine.GameObject.Find("init_logo"));
		}
		
		InvokeRepeating("close_screen", 0.1f, 0.1f);
	}
}
 