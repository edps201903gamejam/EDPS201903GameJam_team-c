using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public float speed = 1.0f;

	void Update ()
	{
		this.transform.position += new Vector3(0f, speed, 0f);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.name == "Player")
		{
			Debug.Log("GameOver");
			SceneManager.LoadScene ("GameOver");
		}
	}
}
