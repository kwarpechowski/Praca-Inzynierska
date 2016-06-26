using UnityEngine;
using System.Collections;

public class NetworkStatusText : MonoBehaviour {

	UnityEngine.UI.Text txt;
	string t = null;

	// Use this for initialization
	void Start () {
		txt = this.gameObject.GetComponent<UnityEngine.UI.Text>();
		NetworkManager.StartListening ("ChangeNetworkStatus", ChangeText);
		ChangeText ();
	}

	void OnDisable ()
	{
		NetworkManager.StopListening ("ChangeNetworkStatus", ChangeText);
	}

 	void ChangeText() {
		if(NetworkManager.Status == NetworkStatus.READY) {
			t = "Oczekuje na połączenie " + NetworkManager.Ip;
		} else if(NetworkManager.Status == NetworkStatus.CONNECTED) {
			t = "Połączono";
		}
	}

	void Update() {
		if (t != null) {
			txt.text = t;
			t = null;
		}
	}
}
