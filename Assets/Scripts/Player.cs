using System.Collections;
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
	
	private float speed = 5.0f;
	private float jumpSpeed = 8.0f;
	public float jumpPower = 1.1f;

	private float timeJump = 0.09f;
	private float countTime;
	
	void Start ()
	{
		//プレイヤーのRigidbody2Dを取得
		rd = gameObject.GetComponent<Rigidbody2D>();
		isGround = false;
		speedUp = false;

		countTime = 0;
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
				if (countTime < timeJump)
				{
					//jumpPowerが第２段階の時とジャンプ力を維持する時
					if (jumpPower == 1.3f || jumpPower == 1.5f)
					{
						jumpPower = 1.5f;
					}
					else
					{
						jumpPower = 1.3f;
					}	
				}
				else
				{
					//普通のジャンプ力
					jumpPower = 1.1f;
				}
				
				rd.velocity = Vector2.up.normalized * jumpSpeed * jumpPower;
//				rd.AddForce(Vector2.up * 350 * jumpPower * Time.deltaTime, ForceMode2D.Impulse);
			}
		}
		else
		{
			countTime = 0;
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
			isGround = true;
			
		}
	}
	
	//Playerが地面にStayしている場合
//	void OnCollisionStay2D(Collision2D c)
//	{
//		if (c.gameObject.tag == "Block")
//		{
//			isGround = true;
//		}
//	}
	
	void OnCollisionExit2D(Collision2D c)
	{
		isGround = false;
	}
}
