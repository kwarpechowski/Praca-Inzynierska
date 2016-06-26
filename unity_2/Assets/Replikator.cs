using UnityEngine;
using System.Collections;

public class Replikator : MonoBehaviour {

	public GameObject lemming;
	public GameObject rura;
	private int lemmingCount = 0;
	public int LemmingSize = 5;
	private int secoundLimit = 10;


	void Start() {
		Run ();
	}

	// Use this for initialization
	public void Run () {
		StartCoroutine(Runner());

		NetworkManager.StartListening("button_1", Left);
		NetworkManager.StartListening("button_2", Right);
		NetworkManager.StartListening("button_3", Kilof);
		NetworkManager.StartListening("button_4", Lopata);
		NetworkManager.StartListening("button_5", Jump);
		NetworkManager.StartListening("button_6", Drabina);
		NetworkManager.StartListening("button_7", Rotate);
		NetworkManager.StartListening("button_8", Startstop);
		NetworkManager.StartListening("button_9", Reset);
	}

	IEnumerator Runner() {
		while (lemmingCount < LemmingSize) {
			Create ();
			lemmingCount += 1;
			yield return new WaitForSeconds (secoundLimit);
		}
	}
		
	void Left () {
		Lemming2.GetPrev ();
	}

	void Right () {
		Lemming2.GetNext ();
	}

	void Kilof () {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.ToggleKilof ();
		}
	}

	void Lopata () {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.ToggleLopata ();
		}
	}

	void Drabina () {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.ToggleDrabina ();
		}
	}

	void Jump () {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.Jump ();
		}
	}

	void Rotate () {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.Rotate ();
		}
	}

	void Startstop() {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.Startstop ();
		}
	}

	void Reset() {
		if (Lemming2.activeEl) {
			Lemming2.activeEl.Restart ();
		}
	}

	void Create() {
		var t = Instantiate(lemming) as GameObject;
		t.transform.parent = rura.transform;
	}
}
