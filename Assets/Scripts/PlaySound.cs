using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
  
public class PlaySound : MonoBehaviour {
  
 private AudioSource sound01;
 private AudioSource sound02;
 private AudioSource sound03;
 private AudioSource sound04;

  
 void Start () {
 //AudioSourceコンポーネントを取得し、変数に格納
 AudioSource[] audioSources = GetComponents<AudioSource>();
 sound01 = audioSources[0]; //BGM
 sound02 = audioSources[1]; //ジャンプ
 sound03 = audioSources[2]; //足音
 sound04 = audioSources[3]; //足音

 //BGM開始
 

if(SceneManager.GetActiveScene().name == "Main"){
	sound01.PlayOneShot(sound01.clip);
	}

 if(SceneManager.GetActiveScene().name == "Main_2"){
	sound04.PlayOneShot(sound04.clip);
	}

  if(SceneManager.GetActiveScene().name == "Main_3"){
	sound04.PlayOneShot(sound04.clip);
	}

 }

 void Update () {
 //ジャンプ
 if(Input.GetKeyDown(KeyCode.Space)) {
 sound02.PlayOneShot(sound02.clip);
 }
}
}