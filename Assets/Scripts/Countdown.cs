using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Countdown : MonoBehaviour {
	public Text timerText;
	public Text itemText;
 
	public float totalTime;
	public  static float seconds;

	public int itemCount;
 
	// Use this for initialization
	void Start ()
	{
		totalTime = 0.0f;
		itemCount = 0;
	}
 
	// Update is called once per frame
	void Update ()
	{
		itemCount = Item.scoreCount;
		
		
		totalTime += Time.deltaTime;
		seconds = totalTime;
		timerText.text= seconds.ToString("f2");

		itemText.text = "アイテム数:" + itemCount.ToString();
	}
}