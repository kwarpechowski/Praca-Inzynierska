using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;
using System.Text;
using System.Collections.Generic;

using UnityEngine.SceneManagement;

public class Network : MonoBehaviour {
	string[] words;
	int wordsNum; 
	private int port = 1337;
	int numSurf;
	int jumpInterval;
	string messagToSend;
	
	Thread listen_thread;
	TcpListener tcp_listener;
	Thread clientThread;
	TcpClient tcp_client;
	private static TcpClient client;
	bool isTrue = true;

	private String lvlName = null;

	public static void EnableButton(ButtonEnum num) {
		Network.SendMessage("enable_" + num);
	}

	public static void DisableButton(ButtonEnum num) {
		Network.SendMessage("disable_" + num);
	}

	public static void TextButton(ButtonEnum num, String text) {
		Network.SendMessage("setText_" + num + "_" + text);
	}

	public static void SendMessage(string messagToSend) {
		if (Network.client != null) {
			Byte[] data = System.Text.Encoding.ASCII.GetBytes(messagToSend+"\n");  
			NetworkStream stream = Network.client.GetStream ();
			stream.Write (data, 0, data.Length);
		}
	}

	private string GetLocalIPAddress()
	{
		return "192.168.0.14";

//		var host = Dns.GetHostEntry(Dns.GetHostName());
//		foreach (var ip in host.AddressList)
//		{
//			if (ip.AddressFamily == AddressFamily.InterNetwork)
//			{
//				Debug.Log (ip.ToString ());
//				return ip.ToString();
//			}
//		}
//		throw new Exception("Local IP Address Not Found!");
	}
	
	void Update () {
		if (lvlName != null) {
			Debug.Log ("load level");
			Application.LoadLevel (lvlName); 
			lvlName = null;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		NetworkManager.Ip = GetLocalIPAddress();
		NetworkManager.StartReady ();

		IPAddress ip_addy = IPAddress.Parse(GetLocalIPAddress());
		tcp_listener = new TcpListener(ip_addy, port);
		listen_thread = new Thread(new ThreadStart(ListenForClients));
		listen_thread.Start();
		BindLevels ();
	
	}

	private void ListenForClients()
	{
		this.tcp_listener.Start();
		
		
		while(isTrue == true)   
		{
			client = this.tcp_listener.AcceptTcpClient();
			clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
			clientThread.Start(client); 
			
			NetworkManager.StartConnected ();


			//Network.SendMessage("count_"+Lemming2.lista.Count);
		}
	}
	
	private void HandleClientComm(object client)
	{
		tcp_client = (TcpClient)client;
		NetworkStream client_stream = tcp_client.GetStream();
		
		byte[] message = new byte[5000];
		int bytes_read;

		while (isTrue == true) {
			bytes_read = 0;
			//blocks until a client sends a message
			bytes_read = client_stream.Read (message, 0, message.Length);

			
			if (bytes_read == 0) {
				//client has disconnected
				NetworkManager.StartReady();
				tcp_client.Close ();
				break;
			}

			string result = Encoding.ASCII.GetString(message, 0, bytes_read);

			Debug.Log ("otrzymalem " + result);

			NetworkManager.TriggerEvent (result);

			result = null;

			if (isTrue == false) {
				NetworkManager.StartReady ();
				tcp_client.Close ();
			}
		}
	}
	
	void OnApplicationQuit()
	{
		try
		{
			tcp_client.Close();
			isTrue = false;
		}
		catch(Exception e)
		{
			Debug.Log(e.Message);
		}
		
		// You must close the tcp listener
		try
		{
			tcp_listener.Stop();
			isTrue = false;
		}
		catch(Exception e)
		{
			Debug.Log(e.Message);
		}
	}

	private void BindLevels() {
		NetworkManager.StartListening ("Calibration", LoadCalibration);
		NetworkManager.StartListening ("Lvl0", LoadFirstLevel);
	}

	private void LoadCalibration(){
		lvlName = "SplashScreen";
	}

	private void LoadFirstLevel() {
		lvlName = "Lvl0";
	}
}
