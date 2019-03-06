using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	//ブロックが存在する時間
	private float timeLimit = 3.0f;

	private float counttime;

	void Start ()
	{
		counttime = 0;

	}
	
	void Update ()
	{
		counttime += Time.deltaTime;

		if (counttime >= timeLimit)
		{
			Destroy(this.gameObject);
		}
	}
}
