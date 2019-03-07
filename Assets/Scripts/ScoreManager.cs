using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

	public int score;
	public int totalScore;
	public int time;

	private float result;
	private float totalResult;

	private float timeScore;
	
	// Use this for initialization
	void Start ()
	{
		score = Item.scoreCount;
		totalScore = Item.totalItem;
		time = Countdown.seconds;

		

		timeScore = 15 - time;

		totalResult = 100 * totalScore;
		result = 100 * score - 10 * time;
		
//		Debug.Log(score);
//		Debug.Log(totalScore);
//		Debug.Log(time);
		
		Debug.Log(timeScore);
		Debug.Log(result);

		if (result >= 495)
		{
			Debug.Log("S");
		}
		else if(result >= 445)
		{
			Debug.Log("A");
		}else if (result >= 385)
		{
			Debug.Log("B");
		}else if (result < 385)
		{
			Debug.Log("C");
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
