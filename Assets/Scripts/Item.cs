using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{


	public static int totalItem;
	public int itemCount = 0;
	
	public static int scoreCount;

	void Start()
	{
		totalItem = GameObject.FindGameObjectsWithTag ("Item").Length;
		scoreCount = 0;
	}
	
	void Update()
	{
		itemCount = GameObject.FindGameObjectsWithTag ("Item").Length;

		scoreCount = totalItem - itemCount;
		
//		Debug.Log(totalItem - itemCount);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			itemCount--;
			Destroy(this.gameObject);
		}
	}
	
}
