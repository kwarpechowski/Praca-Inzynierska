using UnityEngine;
using System.Collections;
using SocketIO;

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
		socket.Emit ("points", new JSONObject(1));
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("points", new JSONObject(2));
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("points", new JSONObject(3));
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("points", new JSONObject(4));
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("points", new JSONObject(5));
		yield return new WaitForSeconds(5);
		Debug.Log("xx");
		socket.Emit ("points", new JSONObject(6));

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
