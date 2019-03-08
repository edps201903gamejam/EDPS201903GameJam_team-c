using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraghtPlayer : MonoBehaviour {

	public GameObject p;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		p.transform.rotation = new Quaternion(0 ,0 ,0, 0);
	}
}
