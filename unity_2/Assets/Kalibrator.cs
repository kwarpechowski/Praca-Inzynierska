using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Kalibrator : MonoBehaviour {

	public GameObject canvas;
	public Text txt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Run() {
		GameObject RG = GameObject.Find ("RG").gameObject;
		Debug.Log ("RG " + RG.transform.position.x);

		GameObject LD = GameObject.Find ("LD").gameObject;
		Debug.Log ("LD " + LD.transform.position.x);

		GameObject LG = GameObject.Find ("LG").gameObject;
		Debug.Log ("LG " + LG.transform.position.x);

		Destroy (canvas);
		txt.text = "Dziękujemy " +  Environment.NewLine +  " Przejdź do menu głównego";
	}
}
