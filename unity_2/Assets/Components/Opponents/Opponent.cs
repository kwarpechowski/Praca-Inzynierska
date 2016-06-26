using UnityEngine;
using System.Collections;

public class Opponent : MonoBehaviour {
	public OpponentModel model;

	Hashtable ht = new Hashtable();
	
	void GenerateMove(){
		ht.Add("path",model.MovePath.ToArray());
		ht.Add("time",15);
		ht.Add("onupdate","myUpdateFunction");
		ht.Add("looptype",iTween.LoopType.loop	);
	}


	// Use this for initialization
	void Start () {
		this.GenerateMove ();
		Debug.Log ("Siema" + this.gameObject.name + " z " +model.Health);
		iTween.MoveTo(gameObject, ht);
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.deltaTime * 20;
		this.gameObject.transform.Rotate(t, t, t);
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Wypadek" + this.gameObject.name + " z " + other.gameObject.name);
		Destroy (this.gameObject);
		//Tutaj naliczyc punkty
	}
}
