using UnityEngine;
using System.Collections;

public class Drabina : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Enter");
		//Lemming2 lemming = collision.gameObject.GetComponent<Lemming2> ();
//		lemming.SetDrabina ();
	}
}
