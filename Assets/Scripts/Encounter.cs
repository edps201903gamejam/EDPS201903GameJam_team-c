using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour {

	public GameObject p;
	private AudioSource bgm;

	public AudioClip enc_bgm;

	// Use this for initialization
	void Start () {
		bgm = p.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		//特定領域に入ったらプレイヤーオブジェクトのBGMを止め、悪夢とエンカウントさせる 
		//プレイヤーオブジェクトのAudio Sourceで緊迫BGMも流す
		if (c.gameObject.tag == "Player")
		{
				bgm.Stop();

				bgm.clip = enc_bgm;

				bgm.Play();
				Destroy(this.gameObject);
		}

		
	}
}
