using UnityEngine;
using System.Collections;
using System;

public class Kopacz : MonoBehaviour {

	private Animator animator;
	private Lemming2 lemming = null;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (lemming && lemming.GetAx()) {
			try {
				animator.SetTrigger("Kop");
				lemming = null;
			}
			catch(Exception) {

			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("oookolizja");
		lemming = collision.gameObject.GetComponent<Lemming2> ();
	}
}
