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
			SceneManager.LoadScene ("Main_2");

		//ステージ2 → ステージ3
		if(SceneManager.GetActiveScene().name == "Main_2"){
			SceneManager.LoadScene ("Main_3");
		}
		//ステージ3 → ゴール
		if(SceneManager.GetActiveScene().name == "Main_3"){
			SceneManager.LoadScene ("GameClear");
		}

		}
	}
}
