using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

	//public GameObject theSphere;
	private VideoPlayer theVideoPlayer;
	//private VideoSource theVideoSource;

	private AudioSource theAudioSource;
	public GazeButton theGazeButton;

	// Use this for initialization
	void Start () {
		/*if (theSphere == null)
			theSphere = GameObject.Find ("Sphere");*/
		theGazeButton = GetComponent<GazeButton> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (theVideoPlayer != null) {
			if (/*(!theGazeButton.GetCondition ()) &&*/ theVideoPlayer.isPrepared) {
				theVideoPlayer.Play ();
				theAudioSource.Play ();
			} 
		}
	}

	public void RealStart(){
		theVideoPlayer = gameObject.AddComponent<VideoPlayer> ();
		//theVideoSource = gameObject.AddComponent<VideoSource> ();
		theAudioSource = gameObject.AddComponent<AudioSource> ();

		theVideoPlayer.source = VideoSource.Url;
		theVideoPlayer.url = "https://storage.googleapis.com/merakivideos/A%20Mumbai%20Summer.mp4";
		//theSphere.AddComponent<VideoPlayer>(theVideoPlayer);

		theVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		theVideoPlayer.EnableAudioTrack (0, true);
		theVideoPlayer.SetTargetAudioSource (0, theAudioSource);
	}

	public void Stream(){
		RealStart ();
		theVideoPlayer.playOnAwake = true;
		theVideoPlayer.Play ();
		theAudioSource.Play ();
	}

	public void Download(){
		RealStart ();
		theVideoPlayer.playOnAwake = false;
		theVideoPlayer.Prepare ();

	}
}
