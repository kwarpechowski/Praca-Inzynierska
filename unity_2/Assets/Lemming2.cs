using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lemming2 : MonoBehaviour {

	public static List<Lemming2> lista = new List<Lemming2>();
	public static Lemming2 activeEl = null;

	public static Vector3 lemmingPosition = new Vector3 (1205.9F, 103.4F, -4996.9F);
	private static Vector3 jumpSize = new Vector3 (0, 200F, 0F);


	private bool isMove;
	private bool drabina;
	private bool jump;
	private bool isMove2 = false;
	private bool resetStatus = false;
	private bool hasAx;
	private bool hasSh;
	private bool rotate;
	private GameObject selected;



	public bool GetAx() {
		return hasAx;
	}


	// Use this for initialization
	void Start () {
		lista.Add (this);
		Network.SendMessage ("count_" + lista.Count);
		selected = this.gameObject.transform.GetChild (0).gameObject;


		Restart ();

		if (Lemming2.activeEl == null) {
			Lemming2.activeEl = this;
		}
	
	}

	public void Restart() {
		hasAx = false;
		hasSh = false;
		drabina = false;
		isMove = true;
		jump = false;
		rotate = false;
		resetStatus = true;
	}

	public static void GetNext() {
		Debug.Log ("get next");
		if (Lemming2.activeEl == null) {
			Lemming2.activeEl = Lemming2.lista [0];
		} else {
			int i = Lemming2.lista.IndexOf(Lemming2.activeEl);
			if (i < Lemming2.lista.Count - 1) {
				Lemming2.activeEl = Lemming2.lista [i + 1];
			} else {
				Lemming2.activeEl = Lemming2.lista [0];
			}
		}

		Lemming2.activeEl.SendInfo ();
	}

	public static void GetPrev() {
		if (Lemming2.activeEl == null) {
			Lemming2.activeEl = Lemming2.lista [Lemming2.lista.Count - 1];
		} else {
			int i = Lemming2.lista.IndexOf(Lemming2.activeEl);
			if (i > 0) {
				Lemming2.activeEl = Lemming2.lista [i - 1];
			} else {
				Lemming2.activeEl = Lemming2.lista [Lemming2.lista.Count - 1];
			}
		}

		Lemming2.activeEl.SendInfo ();
	}

	public void SendInfo() {
		Network.SendMessage("hasax_"+this.hasAx);
		Network.SendMessage("hassh_"+this.hasSh);
		Network.SendMessage("hasdrabina_"+this.drabina);
		Network.SendMessage("isMove_"+this.isMove);
	}

	void OnDestroy () {
		if (activeEl != null && this.GetInstanceID () == activeEl.GetInstanceID ()) {
			GetNext ();
		}

		lista.Remove (this);
	}

	private void AddSelected() {
		selected.transform.localScale = new Vector3 (100, 10, 100);
	}

	private void RemoveSelected() {
		selected.transform.localScale = new Vector3 (0, 0, 0);
	}

	//zrobic get/set
	public void ToggleKilof() {
		hasAx = !hasAx;
		SendInfo ();
	}

	public void ToggleLopata() {
		hasSh = !hasSh;
		SendInfo ();
	}

	public void ToggleDrabina() {
		drabina = !drabina;
		SendInfo ();
	}


	public void Jump() {
		jump = true;
		SendInfo ();
	}

	public void Rotate() {
		rotate = true;
		SendInfo ();
	}

	public void Startstop() {
		isMove = !isMove;
		SendInfo ();
	}
		
	// Update is called once per frame
	void Update () {

		if (resetStatus) {
			transform.localPosition = lemmingPosition;
			resetStatus = false;
		}

		if (isMove) {
			transform.Translate (new Vector3 (-300F, -300F, 0F) * Time.deltaTime);
		} else if (drabina) {
			transform.Translate (new Vector3 (0, -100F, 0F) * Time.deltaTime);
		} else {
			//transform.Translate (new Vector3 (0, -900F, 0F) * Time.deltaTime);

			//Destroy (gameObject);
		}

		if (Lemming2.activeEl == this) {
			AddSelected ();
		} else {
			RemoveSelected ();
		}

		if (jump) {
			transform.Translate (jumpSize);
			jump = false;
		}

		if (rotate) {
			transform.Rotate (0, 180F, 0);
			rotate = false;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "spadek") {
			isMove = true;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "spadek") {
			isMove = false;
		}
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.name.Contains ("Lemming")) {
			isMove = false;
		}
	}

	void OnCollisionExit(Collision other) {
		if (other.gameObject.name.Contains ("Lemming")) {
			isMove = true;
		}
	}
}
