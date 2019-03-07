using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {
	Animator anim;

	// Use this for initialization
	void Start () {
		//Animatorをキャッシュ
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		//左向きでジャンプしたとき
		if(Input.GetKeyDown(KeyCode.Space)){
			anim.SetBool("stay_jump",true);
		} else if(Input.GetKeyUp(KeyCode.Space)){
			anim.SetBool("stay_jump",false);
		}

		/*走りながら右向きでジャンプしたとき
		if(Input.GetKeyDown(KeyCode.Space) & anim.GetBool("run_right")){
			anim.SetBool("run_jump_right",true);
		} else if(Input.GetKeyUp(KeyCode.Space)){
			anim.SetBool("run_jump_right",false);
		}
		*/

		//左移動
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			anim.SetBool("run",true);

			anim.SetBool("stay_right",false);
		} else if(Input.GetKeyUp(KeyCode.LeftArrow)){
			anim.SetBool("run",false);
		}

		//右移動
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			anim.SetBool("run_right",true);
		} else if(Input.GetKeyUp(KeyCode.RightArrow)){
			anim.SetBool("run_right",false);

			anim.SetBool("stay_right",true);
		}

		/*
		if(Input.GetKeyDown(KeyCode.Space)){
		anim.SetTrigger("jump");
		}
		*/
		
	}

}
