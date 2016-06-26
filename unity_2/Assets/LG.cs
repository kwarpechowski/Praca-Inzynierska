using UnityEngine;
using System.Collections;
using AssemblyCSharp;
using UnityEngine.UI;

public class LG : MonoBehaviour {

	public GameObject nextElement;
	public GameObject kalibrator;
	public bool isStart = false;
	protected bool md = false;
	protected bool mp = false;
	protected bool ml = false;
	protected bool mr = false;
	private bool ne = false;

	// Update is called once per frame
	void Update () {
		if (md) {
			transform.Translate (new Vector3 (0F, -300F, 0F) * Time.deltaTime);
			md = false;
		}

		if (mp) {
			transform.Translate (new Vector3 (0F, 300F, 0F) * Time.deltaTime);
			mp = false;
		}

		if (ml) {
			transform.Translate (new Vector3 (300F, 0F, 0F) * Time.deltaTime);
			ml = false;
		}

		if (mr) {
			transform.Translate (new Vector3 (-300F, 0F, 0F) * Time.deltaTime);
			mr = false;
		}

		if (ne) {
			Stop ();
			if (nextElement != null) {
				nextElement.GetComponent<LG> ().Runner ();
			} else {
				kalibrator.GetComponent<Kalibrator> ().Run ();
			}
			ne = false;
				
		}
	}

	void MoveDown() {
		md = true;
	}

	void MoveUp() {
		mp = true;
	}

	void MoveRight() {
		mr = true;
	}

	void MoveLeft() {
		ml = true;
	}

	void Run() {
		NetworkManager.StartListening ("button_5", MoveDown);
		NetworkManager.StartListening ("button_3", MoveUp);
		NetworkManager.StartListening ("button_2", MoveLeft);
		NetworkManager.StartListening ("button_1", MoveRight);
	}


	// Use this for initialization
	void Start () {
		if (isStart) {
			Runner ();
		}
	}

	public void Runner() {
		Run ();
		GetComponent<Image>().color = Color.red;
		NetworkManager.StartListening ("button_6", NextElement);
	}

	void NextElement() {
		ne = true;
	}

	void Stop () {
		GetComponent<Image>().color = Color.white;
		NetworkManager.StopListening ("button_5", MoveDown);
		NetworkManager.StopListening ("button_3", MoveUp);
		NetworkManager.StopListening ("button_2", MoveLeft);
		NetworkManager.StopListening ("button_1", MoveRight);
		NetworkManager.StopListening ("button_6", NextElement);
	}
}
