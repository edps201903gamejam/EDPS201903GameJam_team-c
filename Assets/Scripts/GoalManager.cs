using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour {

	//Playerタグに当たるとゴール
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player")
		{
			Debug.Log("goal");
			SceneManager.LoadScene ("GameClear");
		}
	}
}
