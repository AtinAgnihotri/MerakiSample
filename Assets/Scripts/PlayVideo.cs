using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;

public class PlayVideo : MonoBehaviour {

	//public GameObject theSphere;
	private VideoPlayer theVideoPlayer;
	//private VideoSource theVideoSource;

	private AudioSource theAudioSource;
	public GazeButton theGazeButton;

	public Text v1Txt;

	//private bool downloadCalled;

	// Use this for initialization
	void Start () {
		/*if (theSphere == null)
			theSphere = GameObject.Find ("Sphere");*/
		theGazeButton = GetComponent<GazeButton> ();

		v1Txt = GameObject.Find ("v1").GetComponent<Text> ();

		//downloadCalled = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (theVideoPlayer != null) {
			if (/*(!theGazeButton.GetCondition ()) && theVideoPlayer.isPrepared) {
				theVideoPlayer.Play ();
				theAudioSource.Play ();
			} 
		}*/



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

	public IEnumerator Download(){
		/*RealStart ();
		theVideoPlayer.playOnAwake = false;
		theVideoPlayer.Prepare ();*/

		WWW www = new WWW ("https://storage.googleapis.com/merakivideos/A%20Mumbai%20Summer.mp4");


		while (!www.isDone) {
			v1Txt.text = "Downloaded :" + (www.progress * 100).ToString () + " % ";
			yield return null;
		}

		string dataPath = Application.persistentDataPath + "/aMumbaiSummer.mp4";

		File.WriteAllBytes (dataPath, www.bytes);

		theVideoPlayer = gameObject.AddComponent<VideoPlayer> ();
		//theVideoSource = gameObject.AddComponent<VideoSource> ();
		theAudioSource = gameObject.AddComponent<AudioSource> ();

		theVideoPlayer.playOnAwake = false;
		theAudioSource.playOnAwake = false;

		theVideoPlayer.source = VideoSource.Url;
		theVideoPlayer.url = dataPath ;
		//theSphere.AddComponent<VideoPlayer>(theVideoPlayer);

		theVideoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
		theVideoPlayer.EnableAudioTrack (0, true);
		theVideoPlayer.SetTargetAudioSource (0, theAudioSource);

		theVideoPlayer.Prepare ();

		while (!theVideoPlayer.isPrepared) {
			v1Txt.text = "Preparing Video";
		}

		theVideoPlayer.Play ();
		theAudioSource.Play ();

		//return 0;

		}
}
