using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
	//取得音
	private AudioSource[] audioSources;
    private AudioSource get;
	private AudioSource BGM;

	private AudioSource Enc_BGM;

	public Text ItemText;


	public static int totalItem;
	public int itemCount = 0;
	
	public static int scoreCount;

	void Start()
	{
		totalItem = GameObject.FindGameObjectsWithTag ("Item").Length;
		scoreCount = 0;

 		AudioSource[] audioSources = GetComponents<AudioSource>();
		get = audioSources[0]; //取得
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
			AudioSource.PlayClipAtPoint( get.clip,new Vector3(0,0,0),2);
			
			//ItemText.text += 1;
			Destroy(this.gameObject);
			//取得音
			
			
		}

		
	}
	
}
