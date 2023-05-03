﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
	private string[] mData ={"你好,我是NPC","这是一个Unity3D编写的脚本",
		"对话框是基于GUI实现的","博主是一个喜欢游戏的人","这是一个关于NPC对话的简单实现"
		,"大家就不要笑话这个界面丑陋了啊"};
	//当前对话索引
	private int index = 0;
	//用于显示对话的GUI Text
	public Text mText;
	//对话标示贴图
	public Texture mTalkIcon;
	//是否显示对话标示贴图
	//////////////private bool isTalk = false;
	public GameObject WinUI;
	public GameObject DialogueUI;

	void Update()
	{
		/*从角色位置向NPC发射一条经过鼠标位置的射线
		Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit mHi;
		//判断是否击中了NPC
		if (Physics.Raycast(mRay, out mHi))
		{*/
			//如果击中了NPC
			if (true)
			{
				//进入对话状态
				///////////////////////isTalk = true;
				//允许绘制
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
				{
					//绘制指定索引的对话文本
					if (index < mData.Length)
					{
						mText.text = "NPC:" + mData[index];
						index = index + 1;
					}
					else
					{
					/*index = 0;
					mText.text = "NPC:" + mData[index];*/
					DialogueUI.SetActive(false);
					WinUI.gameObject.SetActive(true);
				}
				
			}
		}
	}

	/*
	void OnGUI()
	{
		if (isTalk)
		{
			//禁用系统鼠标指针
			UnityEngine.Cursor.visible = false;
			Rect mRect = new Rect(Input.mousePosition.x - mTalkIcon.width,
				   Screen.height - Input.mousePosition.y - mTalkIcon.height,
				   mTalkIcon.width, mTalkIcon.height);
			//绘制自定义鼠标指针
			GUI.DrawTexture(mRect, mTalkIcon);
		}

	}*/
}
