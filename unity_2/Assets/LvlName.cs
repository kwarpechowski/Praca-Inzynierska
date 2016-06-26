using UnityEngine;
using System.Collections;

public class LvlName : MonoBehaviour {

	private UnityEngine.UI.Text textComponent;
	private LvlManager lvlManager = new LvlManager ();

	// Use this for initialization
	void Start () {
		textComponent = gameObject.GetComponent<UnityEngine.UI.Text> ();
		textComponent.text = lvlManager.getLevelName ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
