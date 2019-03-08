using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	//画像の色情報などを取得
	private SpriteRenderer r;
	
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

	private float currentTime;

	public bool faidBlock = true;

//	public AudioSource blockBreak;


	//移動床の移動座標と速度
#pragma warning disable 0649
	[SerializeField]
	float moveX;
	[SerializeField]
	float moveY;
	[SerializeField]
	float speed;
	[SerializeField]
	protected float waitTime;

	float step;
	bool goBack = false;
	Vector3 origin;
	Vector3 destination;


	protected bool stop = false;

	void Start ()
	{
		r = this.GetComponent<SpriteRenderer>();
		
		countTime = 0;

		collisionTime = float.MaxValue;

		playerFlag = false;

		currentTime = timeLimit;

		origin = transform.position;
		destination = new Vector3(origin.x - moveX, origin.y - moveY);
	}
	
	void Update ()
	{
		//timeをカウントする
		countTime += Time.deltaTime;

		AlphaUpdate();
		
		//countTimeがtimeLimitを超えたらオブジェクトを消す
		if (IsDestroy() == true && faidBlock == true)
		{
			Destroy(this.gameObject);
//			blockBreak.PlayOneShot(blockBreak.clip);
		}

		if (stop)
		{
			return;
		}

		step = speed * Time.deltaTime;

		//移動床の挙動
		if (!goBack)
		{
			transform.position = Vector3.MoveTowards(transform.position, destination, step);

			if (transform.position == destination)
			{
				goBack = true;

				StartCoroutine(Wait());
			}
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, origin, step);

			if (transform.position == origin)
			{
				goBack = false;

				StartCoroutine(Wait());
			}
		}
	}

	//画像の透明度を変更する処理
	void AlphaUpdate()
	{
		if (playerFlag && faidBlock)
		{
			currentTime -= Time.deltaTime;

			float a = currentTime / timeLimit;
			
			r.color = new Color(1.0f, 1.0f, 1.0f, a);
		}
	}

	//timeLimitの値を超えたかどうかの判定
	bool IsDestroy()
	{
		return countTime - collisionTime > timeLimit;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			collisionTime = countTime;
			playerFlag = true;
		}
	}

	//移動床の往復待機時間
	protected IEnumerator Wait()
	{
		stop = true;

		yield return new WaitForSeconds(waitTime);

		stop = false;
	}
}
