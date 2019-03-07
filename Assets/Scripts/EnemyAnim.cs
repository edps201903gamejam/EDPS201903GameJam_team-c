using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
	private Animator anim;
	
	
	void Start ()
	{
		anim = GetComponent("Animator") as Animator;
		
		var _spriteRenderer = GetComponent<SpriteRenderer>();
		var _m = _spriteRenderer.localToWorldMatrix;
		var _sprite = _spriteRenderer.sprite;
		var _halfX = _sprite.bounds.extents.x;
		var _halfY = _sprite.bounds.extents.y;
		var _vec = new Vector3(-_halfX, _halfY, 0f);
		var _pos = _m.MultiplyPoint3x4(_vec);
		Debug.Log("1 : " + _pos);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			anim.SetBool("left", true);
			anim.SetBool("right", false);
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			anim.SetBool("right", true);
			anim.SetBool("left", false);
		}
	}
}
