using UnityEngine;
using System.Collections;

public class ScianaMala : MonoBehaviour {

	private bool isShow = true;


	public void Toggle() {
		isShow = !isShow;
		Debug.Log (isShow);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
