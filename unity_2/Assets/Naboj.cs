using UnityEngine;
using System.Collections;

public class Naboj : MonoBehaviour {
	private Animator animator;
	private bool strzel = false;
	public bool wystrzelono = false;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		this.Strzel ();
	}
	
	// Update is called once per frame
	void Update () {
		if (strzel) {
			animator.SetTrigger("Wystrzel");
			strzel = false;
		}

		if (wystrzelono) {
			Debug.Log ("spierdalam");
			Destroy (this.gameObject);
		}
	}

	void Strzel () {
		strzel = true;
	}
}
