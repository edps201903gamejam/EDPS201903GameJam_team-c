using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//プレイヤーのRigidBody2D
	private Rigidbody2D rd;

	//地面に付いているかどうか
	public bool isGround;
	public bool isSecondJump;

	//ハイジャンプのフラグ
	public bool speedUp;
	
	//移動速度
	private float speed = 5.0f;
	//ジャンプの高さ
	public float jumpSpeed = 15.0f;
	//ジャンプの力
	public float jumpPower = 1.3f;

	private float timeJump = 0.25f;
	
	private float countTime;
	
	public bool maxJump;

	public GameObject effect;

	public int jumpCount;
	
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

		jumpCount = 0;

		isSecondJump = false;
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
		if (isSecondJump)
		{
			SecoundJump();
		}
		
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
					if (jumpCount == 0)
					{
						jumpPower = 1.3f;
						jumpCount++;
					}else if (jumpCount == 1)
					{
						jumpPower = 1.5f;
						jumpCount++;
						maxJump = true;
					}
					else if(jumpCount == 2)
					{
						jumpPower = 1.0f;
						jumpCount = 0;
						maxJump = false;
					}
				}
				else
				{
					//普通のジャンプ力
					jumpPower = 1.0f;
					jumpCount = 0;
					maxJump = false;
				}

				//プレイヤーのジャンプ処理
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

	void SecoundJump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rd.velocity = Vector2.up.normalized * jumpSpeed;
			isSecondJump = false;
		}
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
			isSecondJump = false;
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
			isSecondJump = false;
		}
	}
	
	void OnCollisionExit2D(Collision2D c)
	{
		isGround = false;
		isSecondJump = true;
	}
}
