using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private float speed = 0.025f;

	void Update ()
	{
		this.transform.position += new Vector3(0f, speed, 0f);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Player")
		{
			Debug.Log("GameOver");
		}
	}
}
