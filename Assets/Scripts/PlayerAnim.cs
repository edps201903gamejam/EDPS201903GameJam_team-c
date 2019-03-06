using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {
	public Animator animCon;  //  アニメーションするための変数

	// Use this for initialization
	void Start () {
		animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
		//animCon.Play(jump);
		}
		
	}
}
