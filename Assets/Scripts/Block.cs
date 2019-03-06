using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	//ブロックが存在する時間
	private float timeLimit = 1.0f;

	//秒数を数える変数
	private float countTime;
	
	//現在のブロックの個数
	private int currentBlock;

	//ぶつかった時の時間
	private float collisionTime;

	void Start ()
	{
		countTime = 0;

		collisionTime = float.MaxValue;

		foreach (Transform block in this.transform)
		{
			Debug.Log(block.transform.name);
		}
	}
	
	void Update ()
	{
		//timeをカウントする
		countTime += Time.deltaTime;

		//countTimeがtimeLimitを超えたらオブジェクトを消す
		if (IsDestroy() == true)
		{
			Destroy(this.gameObject);
		}
	}

	bool IsDestroy()
	{
		return countTime - collisionTime >= timeLimit;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			collisionTime = countTime;
		}
	}
}
