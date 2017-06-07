using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventMaster : MonoBehaviour {

	public static bool toDownload;
	public GameObject theVr;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		theVr = GameObject.Find ("GvrEditorEmulator");
		theVr.SetActive (false);
	}

	public void ToStream(){
		toDownload = false;
		theVr.SetActive (true);
		SceneManager.LoadScene ("_scene");
	}

	public void ToDownload(){
		toDownload = true;
		theVr.SetActive (true);          	
		SceneManager.LoadScene ("_scene");
	}
}
