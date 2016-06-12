using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;

public class Network : MonoBehaviour {

	private SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		Debug.Log ("startuje");
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", TestOpen);
		socket.On("button", Button);

		StartCoroutine (RunPoints());
	}

	IEnumerator RunPoints() {
		yield return new WaitForSeconds(5);
		Debug.Log("xx");

		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", "button1");
		JSONObject jo = new JSONObject (dic);


		socket.Emit ("disable_button", jo);
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("disable_button", jo);
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("disable_button", jo);
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("disable_button", jo);
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("disable_button", jo);
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("disable_button", jo);

	}

	public void TestOpen(SocketIOEvent e) {
		socket.Emit ("register_game");
	}

	public void Button(SocketIOEvent e) {
		Debug.Log ("xxxxX "+ e.data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
