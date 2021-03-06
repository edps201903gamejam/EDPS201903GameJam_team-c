﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのイベントを作成するクラス
/// </summary>
public class EventBlock : MonoBehaviour
{
	public GameObject enemy;
	public GameObject subCamera;

	public bool EnemyFlag;
	void Start()
	{
		enemy.SetActive(false);
		subCamera.SetActive(false);
		EnemyFlag = false;
	}

	void Update()
	{
		if (EnemyFlag)
		{
			enemy.SetActive(true);
			subCamera.SetActive(true);
		}
	}
	
	//プレイヤーがブロックの上に乗ったら敵キャラを表示
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
//			Debug.Log("のった");
//			enemy.SetActive(true);
			EnemyFlag = true;
		}
	}

}
