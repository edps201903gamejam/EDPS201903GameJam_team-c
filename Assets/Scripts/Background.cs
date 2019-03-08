using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
 {
	void Update()
	{
		float scroll = Mathf.Repeat (Time.time * 0.2f, 1);
		Vector2 offset = new Vector2 (scroll, 0);
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}