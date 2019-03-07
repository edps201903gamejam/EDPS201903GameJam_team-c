using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Countdown : MonoBehaviour {
	public Text timerText;
 
	public float totalTime;
	public  static int seconds;
 
	// Use this for initialization
	void Start ()
	{
		totalTime = 0.0f;
	}
 
	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();
	}
}