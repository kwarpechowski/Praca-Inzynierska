using UnityEngine;
using System.Collections;

public class StartGameLabel : MonoBehaviour {

	// Use this for initialization
	UnityEngine.UI.Text txt;
	string t = null;
	private bool beingHandled = false;
	private int dotted = 0;
	private bool loadLevel = false;
	public string firstLevelName;

	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<UnityEngine.UI.Text>();
		txt.text = "";
		NetworkManager.StartListening ("ChangeNetworkStatus", ChangeText);
		ChangeText ();
	}

	void OnDisable ()
	{
		NetworkManager.StopListening ("ChangeNetworkStatus", ChangeText);
	}

	void ChangeText() {
		if(NetworkManager.Status == NetworkStatus.READY) {
			t = NetworkManager.Ip;
		} else if(NetworkManager.Status == NetworkStatus.CONNECTED) {
			loadLevel = true;
		}
	}

	void Update() {

		if (loadLevel) {
			Application.LoadLevel (firstLevelName);

		}

		if(!beingHandled) {
			if (!string.IsNullOrEmpty (t)) {
				txt.text = txt.text + t [0];
				t = t.Remove (0, 1);
			} else if (dotted < 3) {
				txt.text += ".";
				dotted += 1;
			} else {
				txt.text = txt.text.Remove(txt.text.Length - 3);
				dotted = 0;
			}
			StartCoroutine (Wander ());
		}
	}

	IEnumerator Wander() {
		beingHandled = true;
		// process pre-yield
		yield return new WaitForSeconds( 0.5f );
		// process post-yield
		beingHandled = false;
	}
}


