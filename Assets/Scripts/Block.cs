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
	
	//色情報
	private float red = 1.0f;
	private float green = 1.0f;
	private float blue = 1.0f;
	private float alpha = 1.0f;

	public bool playerFlag;
	
	void Start ()
	{
		countTime = 0;

		collisionTime = float.MaxValue;

		playerFlag = false;
	}
	
	void Update ()
	{
		//timeをカウントする
		countTime += Time.deltaTime;

		AlphaUpdate();
		
		//countTimeがtimeLimitを超えたらオブジェクトを消す
		if (IsDestroy() == true)
		{
			Destroy(this.gameObject);
		}
	}

	//画像の透明度を変更する処理
	void AlphaUpdate()
	{
		if (playerFlag)
		{
			this.GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
			alpha -= Time.deltaTime / 255f;
		}
	}

	//timeLimitの値を超えたかどうかの判定
	bool IsDestroy()
	{
		return countTime - collisionTime >= timeLimit;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			collisionTime = countTime;
			playerFlag = true;
		}
	}
}
