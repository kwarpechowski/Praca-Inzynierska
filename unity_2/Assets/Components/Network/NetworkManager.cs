using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class NetworkManager {

	private static NetworkManager networkManager;

	private static NetworkStatus status;

	public static NetworkStatus Status
	{
		get { return status; }
		set {
			status = value;
			TriggerEvent ("ChangeNetworkStatus");
		}
	}

	public static string Ip;
	public static Dictionary <string, UnityEvent> eventDictionary =  new Dictionary<string, UnityEvent>();
		

	public static bool StringComparison (string s1, string s2)
	{
		if (s1.Length != s2.Length) return false;
		Debug.Log ("check " + s1 + " " + s2); 
		for (int i = 0; i < s1.Length; i++) {
			if (s1 [i] != s2 [i]) {
				Debug.Log ("The " + i.ToString () + "th character is different." + s1[i] + " " + s2[i]);
				return false;
			}
		}
		return true;
	}

	public static void StartReady() {
		Status = NetworkStatus.READY;
	}

	public static void StartConnected() {
		Status = NetworkStatus.CONNECTED;
	}

	public static void StartListening (string eventName, UnityAction listener)
	{
		Debug.Log ("****************************************************** start listen " + eventName); 
		UnityEvent thisEvent = null;
		if (eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		} 
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			eventDictionary.Add (eventName, thisEvent);
		}
	}

	public static void StopListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}

	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;

		Debug.Log ("****************************************************** trigger " + eventName); 

		if (NetworkManager.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke();
		}
	}


}
