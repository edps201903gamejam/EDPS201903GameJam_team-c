using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵キャラのアニメーションを管理するクラス
/// </summary>
public class EnemyAnim : MonoBehaviour
{
	private Animator anim;

	public GameObject targetPlayer;

	private Vector2 plyaerPos;

	private SpriteRenderer srender;
	
	void Start ()
	{
		//Animatorを取得
		anim = GetComponent("Animator") as Animator;
		
		//プレイヤーを取得
		targetPlayer = GameObject.FindGameObjectWithTag("Player");
		//プレイヤーの現在の座様を取得
		plyaerPos = targetPlayer.transform.position;
	}
	
	void Update () {
		//プレイヤーの座標を取得し続ける
		plyaerPos = targetPlayer.transform.position;
		
		//プレイヤーが座標0以上だと目が右に動く
		if (plyaerPos.x >= 0)
		{
			anim.SetBool("right", true);
			anim.SetBool("left", false);
		}
		//プレイヤーが座標0以下だと目が右に動く
		else if (plyaerPos.x <= 0)
		{
			anim.SetBool("left", true);
			anim.SetBool("right", false);
		}
	}
}
