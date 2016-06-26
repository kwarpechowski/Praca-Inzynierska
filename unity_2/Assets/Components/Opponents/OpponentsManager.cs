using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpponentsManager : MonoBehaviour {

	// Use this for initialization
	public GameObject gun;
	public GameObject abstractOpponent;
	public UnityEngine.UI.Image loader;
	public UnityEngine.UI.Text loaderText;
	private float size;
	private List<GameObject> elements = new List<GameObject>();
	private LvlManager lvlManager = null;
	private bool isLoaded = false;
	private bool isCheck = false;


	void Start() {

		lvlManager = new LvlManager();
		NetworkManager.StartListening ("ChangeNetworkStatus", BuildOpponents);
		this.BuildOpponents ();
	}

	private void BuildOpponents() {
		isLoaded = true;
	}

	private void Generate () {
		List<OpponentModel> opponents = lvlManager.getOpponents ();

		foreach(OpponentModel op in opponents) {
			this.AddOpponent(op);
		}

		this.size = (float) opponents.Count;

		isLoaded = false;
		isCheck = true;
	}

	private GameObject AddOpponent(OpponentModel op) {
		Debug.Log ("addOppoent");
		GameObject clone;
		clone = Instantiate (abstractOpponent, op.Pos, Quaternion.identity) as GameObject;
		clone.GetComponent<Opponent> ().model = op;
		elements.Add (clone);
		return clone;
	}
		

	// Update is called once per frame
	void Update () {

		if (isLoaded) {
			Generate ();
		}

		elements.RemoveAll((o)=>o == null);
		float width = 0;


		if (elements.Count != this.size) {
			width = 1 - (elements.Count / this.size);
		}

		loader.fillAmount = width;
		loaderText.text = width*100 + "%";
		
		if (isCheck && elements.Count == 0) {
			lvlManager.nextLevel();
		}


	}
}
