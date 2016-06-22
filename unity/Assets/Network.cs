using UnityEngine;
using System.Collections;
using SocketIO;
using System.Collections.Generic;
using AssemblyCSharp;
public class Network : MonoBehaviour {

	private SocketIOComponent socket;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", InitGame);
		socket.On("button", Button);
	}

    public void InitGame(SocketIOEvent e)
    {
        socket.Emit("register_game");
        EnableButton(ButtonEnum.BUTTON1);
        SetText(ButtonEnum.BUTTON1, "Nazwa 1");
        DisableButton(ButtonEnum.BUTTON2);
    }

    public void DisableButton(ButtonEnum btn) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		socket.Emit ("disable_button", new JSONObject (dic));
	}

	public void EnableButton(ButtonEnum btn) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		socket.Emit ("enable_button", new JSONObject (dic));
	}

	public void SetText(ButtonEnum btn, string text) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		dic.Add ("text", text);
		socket.Emit ("set_text", new JSONObject (dic));
	}


	public void Button(SocketIOEvent e) {
		Debug.Log ("xxxxX "+ e.data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
