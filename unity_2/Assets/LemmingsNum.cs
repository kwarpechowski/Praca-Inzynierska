using UnityEngine;
using System.Collections;

public class LemmingsNum : MonoBehaviour {
	private UnityEngine.UI.Text textElement;

	// Use this for initialization
	void Start () {
		textElement = this.GetComponent<UnityEngine.UI.Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		textElement.text = Lemming.lista.Count.ToString();
	}
}
