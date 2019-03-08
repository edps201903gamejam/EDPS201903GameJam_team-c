using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour {
	Animator anim;
	private float count;

	// Use this for initialization
	void Start () {
		//Animatorをキャッシュ
		anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () {

		//タイトル開始後、5秒たったらキー入力を受け付ける
		count += Time.deltaTime;
		if (Input.anyKey & count > 3.0f){
			anim.SetBool("Start",true);
		}	
		
	}

	void move_scene(){

		if(SceneManager.GetActiveScene().name == "Title"){
		//ゲーム画面へ移動
		SceneManager.LoadScene ("Main");
		}else if(SceneManager.GetActiveScene().name == "GameClear"){
		//タイトル画面へ移動
		SceneManager.LoadScene ("Title");
		}
	}

}
