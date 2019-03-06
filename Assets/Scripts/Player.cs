using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float speed = 5.0f;
	private float jumpSpeed = 8.0f;

	//プレイヤーのRigidBody2D
	private Rigidbody2D rd;

	//地面に付いているかどうか
	public bool isGround;

	//ハイジャンプのフラグ
	public bool hiJump = false;
	
	void Start (){
		//プレイヤーのRigidbody2Dを取得
		rd = gameObject.GetComponent<Rigidbody2D>();
		isGround = false;
	}
	
	void Update () {
		Move();
		Jump();
	}

	//歩く処理
	void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");

		rd.velocity = new Vector2(x * speed, rd.velocity.y);
	}

	//ジャンプ処理
	void Jump()
	{
		if (isGround)
		{
//			Debug.Log();
			if (Input.GetKeyDown(KeyCode.Space))
			{
//				Debug.Log("isGround = false");
				if (hiJump == false)
				{
					//普通のジャンプ
					rd.velocity = Vector2.up.normalized * jumpSpeed;
				}
				else
				{
					//ハイジャンプ
					rd.velocity = Vector2.up.normalized * jumpSpeed * 2;
				}
//				isGround = false;
			}
			
		}
	}
	
	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.tag == "Block")
		{
//			if (!isGround)
//			{
//				Debug.Log("isGround = true");
				isGround = true;
//			}
		}
	}
	
	void OnCollisionExit2D(Collision2D c)
	{
		isGround = false;
	}
}
