using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour {

	private VideoPlayer theVideoPlayer;
	private VideoSource theVideoSource;
	private AudioSource theAudioSource;


	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		//StartCoroutine (PlayVideo());
	}

	//IEnumerator PlayVideo(){
		
	//}
	
	// Update is called once per frame
	void Update () {
		
	}
}
