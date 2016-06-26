using UnityEngine;
using System.Collections;

public class LogoAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.deltaTime * 20;
		this.gameObject.transform.Rotate(t, t, t);
	}
}
