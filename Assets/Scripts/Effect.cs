using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エフェクトを削除するクラス
/// </summary>
public class Effect : MonoBehaviour {
	void Update () {
		Destroy(this.gameObject, 0.25f);
	}
}
