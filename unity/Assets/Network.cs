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
