﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

	void Update () {
		Destroy(this.gameObject, 0.25f);
	}
}
