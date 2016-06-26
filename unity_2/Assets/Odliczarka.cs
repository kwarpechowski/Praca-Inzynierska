using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Odliczarka : MonoBehaviour {
	private int i = 10;
	private Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
		StartCoroutine(ChangeText());
	}

	IEnumerator ChangeText() {
		while (i >= 0) {
			textComponent.text = i.ToString();
			i--;

			if (i == 3) {
				GameObject.Find ("Rura").GetComponent<Rura> ().Run ();
			}
			yield return new WaitForSeconds (1);
		}
		Destroy (GameObject.Find ("Ekran"));

		GameObject.Find ("SpadajacyKlocek1").GetComponent<SpadajacyKlocek> ().Run ();
		GameObject.Find ("SpadajacyKlocek2").GetComponent<SpadajacyKlocek> ().Run ();
		GameObject.Find ("SpadajacyKlocek3").GetComponent<SpadajacyKlocek> ().Run ();
		GameObject.Find ("Replikator").GetComponent<Replikator> ().Run ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
