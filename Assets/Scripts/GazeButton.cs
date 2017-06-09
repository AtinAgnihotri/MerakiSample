using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GazeButton : MonoBehaviour {

	public static bool toStream;
	//private bool buttonPress;
	public Image streamImg;
	public Image downImg;
	public Slider progress;
	public Text txt;
	//public WWW url;
	//public GvrVideoPlayerTexture
	private PlayVideo thePlayVideo;
	public Camera theCamera;


	// Use this for initialization
	void Start () {

		if (theCamera == null)
			theCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();

		if(streamImg == null)
			streamImg = GameObject.Find ("StreamImage").GetComponent<Image>();
		
		if(downImg == null)
			downImg = GameObject.Find ("DownImage").GetComponent<Image>();

		streamImg.color = Color.green;
		downImg.color = Color.red;

		if (progress == null)
			progress = GameObject.Find ("ProgressSlider").GetComponent<Slider> ();

		progress.value = 0;
		progress.gameObject.SetActive (false);

		if (txt == null)
			txt = GameObject.Find ("GuideText").GetComponent<Text>();

		thePlayVideo = FindObjectOfType<PlayVideo> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (progress.IsActive()) {
			progress.value += 1;

			if (progress.value >= progress.maxValue /*&& buttonPress*/) {
				if (toStream) {
					streamImg.color = Color.gray;
					streamImg.gameObject.SetActive (false);
					downImg.gameObject.SetActive (false);
					progress.gameObject.SetActive (false);
					txt.gameObject.SetActive (false);
					//FlipCameraView ();
					thePlayVideo.Stream ();
					//SceneManager.LoadScene("_sceneStream");
				} else {
					downImg.color = Color.gray;
					streamImg.gameObject.SetActive (false);
					downImg.gameObject.SetActive (false);
					progress.gameObject.SetActive (false);
					txt.gameObject.SetActive (false);
					//FlipCameraView ();
					thePlayVideo.Download ();
					//SceneManager.LoadScene("_sceneDown");
				}
				
			}
		}
	}

	public void StreamButtonDown(){
		streamImg.color = Color.blue;
		toStream = true;
		//buttonPress = true;
		progress.gameObject.SetActive (true);
		progress.value = 0;
	}

	public void DownButtonDown(){
		downImg.color = Color.blue;
		toStream = false;
		//buttonPress = true;
		progress.gameObject.SetActive (true);
		progress.value = 0;
	}

	public void StreamButtonUp(){
		streamImg.color = Color.green;
		//buttonPress = false;
		progress.gameObject.SetActive (false);
	}

	public void DownButtonUp(){
		downImg.color = Color.red;
		//buttonPress = false;
		progress.gameObject.SetActive (false);
	}

	public bool GetCondition(){
		return toStream;
	}
	/*
	public void FlipCameraView(){
		theCamera.ResetWorldToCameraMatrix ();
		theCamera.ResetProjectionMatrix ();
		Matrix4x4 mat = theCamera.projectionMatrix;
		mat *= Matrix4x4.Scale(new Vector3(-1,1,1));
		theCamera.projectionMatrix = mat;

	}*/
		
}
