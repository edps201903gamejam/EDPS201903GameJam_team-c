using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
	private Animator anim;

	public GameObject targetPlayer;

	private Vector2 plyaerPos;

	private SpriteRenderer srender;
	
	void Start ()
	{
		//プレイヤーを取得
		targetPlayer = GameObject.FindGameObjectWithTag("Player");
		//プレイヤーの現在の座様を取得
		plyaerPos = targetPlayer.transform.position;
		
		
		anim = GetComponent("Animator") as Animator;
		
		//SpriteRendererを取得
		srender = this.GetComponent<SpriteRenderer>();
		
		var _m = srender.localToWorldMatrix;
		var _sprite = srender.sprite;
		var _halfX = _sprite.bounds.extents.x;
		var _halfY = _sprite.bounds.extents.y;
		var _vec = new Vector3(-_halfX, _halfY, 0f);
		var _pos = _m.MultiplyPoint3x4(_vec);
		Debug.Log("1 : " + _pos);
	}
	
	// Update is called once per frame
	void Update () {
		//プレイヤーの座標を取得し続ける
		plyaerPos = targetPlayer.transform.position;
		
		Debug.Log(plyaerPos.x);
		
		if (plyaerPos.x >= 0 /*Input.GetKeyDown(KeyCode.S)*/)
		{
			
			anim.SetBool("right", true);
			anim.SetBool("left", false);
		}

		else if (plyaerPos.x <= 0/*Input.GetKeyDown(KeyCode.F)*/)
		{
			anim.SetBool("left", true);
			anim.SetBool("right", false);
		}
	}
}
