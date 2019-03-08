using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ブロックのイベントを作成するクラス
/// </summary>
public class EventBlock : MonoBehaviour
{
	public GameObject enemy;

	public bool EnemyFlag;
	
	void Start()
	{
		enemy.SetActive(false);
		EnemyFlag = false;
	}

	void Update()
	{
		if (EnemyFlag)
		{
			enemy.SetActive(true);
		}
	}
	
	//プレイヤーがブロックの上に乗ったら敵キャラを表示
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player")
		{
//			Debug.Log("のった");
//			enemy.SetActive(true);
			EnemyFlag = true;
		}
	}

}
