﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//プレイヤーのRigidBody2D
	private Rigidbody2D rd;

	//地面に付いているかどうか
	public bool isGround;

	//ハイジャンプのフラグ
	public bool speedUp;
	
	//移動速度
	private float speed = 5.0f;
	//ジャンプの高さ
	private float jumpSpeed = 12.5f;
	//ジャンプの力
	public float jumpPower = 1.0f;

	private float timeJump = 0.25f;
	
	private float countTime;
	
	public bool maxJump;

	public GameObject effect;
	
	void Start ()
	{
		//プレイヤーのRigidbody2Dを取得
		rd = gameObject.GetComponent<Rigidbody2D>();
		isGround = false;
		speedUp = false;

		countTime = 0;

		//重力を変更できないようにする
		rd.useAutoMass = false;
		rd.mass = 1.0f;
		rd.gravityScale = 1.0f;

		maxJump = false;
	}
	
	void FixedUpdate ()
	{
		RigidMove();
	}
	
	//rigidbody2Dで移動する
	void RigidMove()
	{
		Move();
		Jump();

//		if (maxJump && isGround)
//		{
//			//プレイヤーの着地エフェクト
//			effect2 = Instantiate(effect, this.transform.position, Quaternion.identity);
//			Destroy(effect2, 0.5f);
//		}
		
	}

	//歩く処理
	void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");

		if (speedUp == true)
		{
			speed = 10.0f;
		}
		
		rd.velocity = new Vector2(x * speed, rd.velocity.y);
	}

	
	
	//ジャンプ処理
	void Jump()
	{
		if (isGround)
		{
			countTime += Time.deltaTime;
			
			if (Input.GetKeyDown(KeyCode.Space))
			{
				
				//countTimeがtimeJump未満ならジャンプ力をあげる
				if (countTime <= timeJump)
				{
					if (jumpPower == 1.3f)
					{
						if (jumpPower == 1.5f)
						{
							maxJump = false;
							jumpPower = 1.0f;
						}
						else
						{
							jumpPower = 1.5f;
							maxJump = true;
						}
					}
					else
					{
						
						jumpPower = 1.3f;
					}	
					
				}
				else
				{
					//普通のジャンプ力
					jumpPower = 1.0f;
					maxJump = false;
				}
				
				rd.velocity = Vector2.up.normalized * jumpSpeed * jumpPower;
			}
		}
		else
		{
			countTime = 0;
			rd.AddForce(Vector2.down.normalized * 22.5f);
		}

		isGround = false;
	}
	
	void OnTriggerEnter2D(Collider2D c)
	{
		//ジャンプ力が上がるアイテムに触れた時
		if (c.gameObject.tag == "PowerItem")
		{
//			Debug.Log("aaa");
			speedUp = true;
			Destroy(c.gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "Block")
		{
			isGround = true;
			if (maxJump)
			{
				Instantiate(effect, this.transform.position, Quaternion.identity);
			}

		}
	}
	
	//Playerが地面にStayしている場合
	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.tag == "Block")
		{
			isGround = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D c)
	{
		isGround = false;
	}
}
