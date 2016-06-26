using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	UnityEngine.UI.Text txt;
	private bool dot = false;
	private bool beingHandled = false;

	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<UnityEngine.UI.Text>();
		txt.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		if (beingHandled)
			return;

		if (dot) {
			txt.text = System.DateTime.Now.ToString ("H:mm:ss");
		} else {
			txt.text = System.DateTime.Now.ToString("H mm ss");
		}

		dot = !dot;
		StartCoroutine (Wander ());
	}

	IEnumerator Wander() {
		beingHandled = true;
		// process pre-yield
		yield return new WaitForSeconds( 1f );
		// process post-yield
		beingHandled = false;
	}
}
