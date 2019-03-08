using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnim : MonoBehaviour {
	Animator anim;

	//足音
	private AudioSource sound03;

	// Use this for initialization
	void Start () {
		//Animatorをキャッシュ
		anim = GetComponent<Animator>();

		AudioSource[] audioSources = GetComponents<AudioSource>();
		sound03 = audioSources[2]; //足音


		//ゲームが開始したら落下アニメーションを開始する
		if(SceneManager.GetActiveScene().name == "Main"){
			anim.SetBool("falldown",true);
		}
	}
	
	// Update is called once per frame
	void Update () {


// ---------------------------------------------------------------
		//左向きでジャンプしたとき
		if(Input.GetKeyDown(KeyCode.Space) & anim.GetBool("run") == false & anim.GetBool("stay") == true){
			anim.SetBool("stay_jump",true);
			anim.SetBool("stay",true);
		} else if(Input.GetKeyUp(KeyCode.Space)){
		}
		if(Input.GetKeyDown(KeyCode.F) & anim.GetBool("stay") == true){
			anim.SetBool("highjump",true);
		}

		//左向きでハイジャンプ

		//左移動
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			anim.SetBool("run",true);
			anim.SetBool("stay",true);

			anim.SetBool("stay_right",false);
		} else if(Input.GetKeyUp(KeyCode.LeftArrow)){
			anim.SetBool("run",false);
		}

		//左向きに走りながらジャンプした時
		if(Input.GetKeyDown(KeyCode.Space) & anim.GetBool("run") == true){
			anim.SetBool("run_jump",true);
			anim.SetBool("stay",true);
		}


// ---------------------------------------------------------------
		//右移動
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			anim.SetBool("stay_right",false);
			anim.SetBool("stay",false);
			anim.SetBool("run_right",true);
		} else if(Input.GetKeyUp(KeyCode.RightArrow)){
			anim.SetBool("run_right",false);

			anim.SetBool("stay_right",true);
		}

		//右向きでジャンプしたとき
		if(Input.GetKeyDown(KeyCode.Space) & anim.GetBool("stay_right") == true){
			anim.SetBool("stay_jump_right",true);
		} else if(Input.GetKeyUp(KeyCode.Space)){
		}

		//右向きに走りながらジャンプした時
		if(Input.GetKeyDown(KeyCode.Space) & anim.GetBool("run_right") == true & anim.GetBool("run_jump_right") == false){
			anim.SetBool("run_jump_right",true);
		}

		
	}
	// ---------------------------------------------------------------


	//ジャンプが終わったときにアニメーションステートを移動するようにする
	void CatchAnimationEvent(){
		anim.SetBool("stay_jump",false);
		anim.SetBool("stay_jump_right",false);
		anim.SetBool("run_jump",false);
		anim.SetBool("jump_right",false);
		anim.SetBool("run_jump_right",false);
		anim.SetBool("highjump",false);
	}

	//アニメーションに合わせて足音を鳴らす
	void Play_walk(){
		sound03.PlayOneShot(sound03.clip); 
	}

	// ---------------------------------------------------------------

	void GameStart(){
		anim.SetBool("gamestart",true);
	}

	//フォールダウンからstayへ移行
	void StayStart(){
		anim.SetBool("stay",true);
		
	}

}
