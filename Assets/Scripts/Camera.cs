using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	public GameObject player;
	
	void Update ()
	{
		//プレイヤーのY軸に合わせてカメラが移動する
		//this.transform.position = new Vector3(0, player.transform.position.y, -10);
		
		//プレイヤーのX軸、Y軸に合わせてカメラが移動する
//		this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
	}

	void FixedUpdate(){
		//プレイヤーのY軸に合わせてカメラが移動する
		this.transform.position = new Vector3(0, player.transform.position.y, -10);
	}
}
