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
        SetText(ButtonEnum.BUTTON1, "Nazwa 1");
        SetText(ButtonEnum.BUTTON2, "Nazwa 2");
        SetText(ButtonEnum.BUTTON3, "Nazwa 3");
        SetText(ButtonEnum.BUTTON4, "Nazwa 4");
        SetText(ButtonEnum.BUTTON5, "Nazwa 5");
        SetText(ButtonEnum.BUTTON6, "Nazwa 6");
    }

    private void DisableButton(ButtonEnum btn) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		socket.Emit ("disable_button", new JSONObject (dic));
	}

	private void EnableButton(ButtonEnum btn) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		socket.Emit ("enable_button", new JSONObject (dic));
	}

	private void SetText(ButtonEnum btn, string text) {
		Dictionary<string, string> dic = new Dictionary<string, string> ();
		dic.Add ("name", btn.ToString());
		dic.Add ("text", text);
		socket.Emit ("set_text", new JSONObject (dic));
	}

	IEnumerator RunPoints() {

	

		yield return new WaitForSeconds(5);
		DisableButton (ButtonEnum.BUTTON1);
		yield return new WaitForSeconds(5);
		DisableButton (ButtonEnum.BUTTON2);
		yield return new WaitForSeconds(5);
		DisableButton (ButtonEnum.BUTTON3);
		yield return new WaitForSeconds(5);
		DisableButton (ButtonEnum.BUTTON4);
		yield return new WaitForSeconds(5);
		EnableButton (ButtonEnum.BUTTON1);
		yield return new WaitForSeconds(5);
		EnableButton (ButtonEnum.BUTTON2);
		yield return new WaitForSeconds(5);
		EnableButton (ButtonEnum.BUTTON3);
		yield return new WaitForSeconds(5);
		EnableButton (ButtonEnum.BUTTON4);

	}


	public void Button(SocketIOEvent e) {
		Debug.Log ("xxxxX "+ e.data);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
