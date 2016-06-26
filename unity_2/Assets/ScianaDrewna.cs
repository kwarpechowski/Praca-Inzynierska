using UnityEngine;
using System.Collections;
using System;

public class ScianaDrewna : MonoBehaviour {

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
				animator.SetTrigger("Usuwaj");
				lemming = null;
			}
			catch(Exception) {

			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		lemming = collision.gameObject.GetComponent<Lemming2> ();
	}
}
