using UnityEngine;
using System.Collections;
using System;

public class SpadajacyKlocek : MonoBehaviour {

	private Rigidbody rigbody;
	private Animator animator;
	private Lemming2 lemming = null;

	// Use this for initialization
	void Start () {
		rigbody = this.gameObject.GetComponent<Rigidbody> ();
		animator = this.gameObject.GetComponent<Animator> ();

		Run ();
	}
	
	void Update () {
		if (lemming && lemming.GetAx()) {
			animator.SetTrigger("Usuwaj");
			lemming = null;
		}
	}

	void OnCollisionEnter(Collision collision) {
		

		if (collision.gameObject.name.Equals ("Lemming(Clone)")) {
			lemming = collision.gameObject.GetComponent<Lemming2> ();
		} else {
			rigbody.isKinematic = true;
		}
	}

	public void Run() {
		rigbody.isKinematic = false;
	}
}
