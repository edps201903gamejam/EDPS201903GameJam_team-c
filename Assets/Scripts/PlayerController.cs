using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Vector3 move;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position += new Vector3(10 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
		}
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
//			this.transform.position.y += 100;
		}
	}
}
