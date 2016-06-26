using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lemming : MonoBehaviour {

	private GameObject active;
	public static List<Lemming> lista = new List<Lemming>();
	public static Lemming activeEl = null;
	private bool isMove = true;
	private Vector3 vector = Vector3.left;

	public void GetNext() {
		Debug.Log ("get next");
		if (Lemming.activeEl == null) {
			Lemming.activeEl = Lemming.lista [0];
		} else {
			int i = Lemming.lista.IndexOf(Lemming.activeEl);
			if (i < Lemming.lista.Count - 1) {
				Lemming.activeEl = Lemming.lista [i + 1];
			} else {
				Lemming.activeEl = Lemming.lista [0];
			}
		}
	}

	public void GetPrev() {
		Debug.Log ("get prev");
		if (Lemming.activeEl == null) {
			Lemming.activeEl = Lemming.lista [Lemming.lista.Count - 1];
		} else {
			int i = Lemming.lista.IndexOf(Lemming.activeEl);
			if (i > 0) {
				Lemming.activeEl = Lemming.lista [i - 1];
			} else {
				Lemming.activeEl = Lemming.lista [Lemming.lista.Count - 1];
			}
				
		}

	}

	// Use this for initialization
	void Start () {
	//	active = this.transform.FindChild ("Active").gameObject;
		lista.Add (this);
	

	}
	
	// Update is called once per frame
	void Update () {


		if (isMove) {
			transform.Translate(vector *300F * Time.deltaTime);
		}
	}

	void OnDestroy () {
		if (activeEl != null && this.GetInstanceID () == activeEl.GetInstanceID ()) {
			GetNext ();
		}

		lista.Remove (this);
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log (collision.gameObject.name);
		if (collision.gameObject.name == "sciana") {
			transform.eulerAngles = new Vector3 (270, 0, 0);
		}
	}

	void OnCollisionExit(Collision collision) {

	}
}
