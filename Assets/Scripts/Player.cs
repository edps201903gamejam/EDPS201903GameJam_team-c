using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private float speed = 5.0f;
	private float jumpSpeed = 8.0f;

	private Rigidbody2D rd;


	private bool isGround = false;
	
	void Start (){
		rd = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		Move();
		Jump();
	}

	void Move()
	{
		float x = Input.GetAxisRaw("Horizontal");

		rd.velocity = new Vector2(x * speed, rd.velocity.y);
	}

	void Jump()
	{
		if (isGround)
		{
//			Debug.Log();
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rd.velocity = Vector2.up.normalized * jumpSpeed;
				isGround = false;
			}
			
		}
	}
	
	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.tag == "Block")
		{
			if (!isGround)
			{
				isGround = true;
			}
		}
	}
	

	
}
