using UnityEngine;
using System.Collections;

public class LemmingCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RotateLeft () {
		Vector3 temp = this.gameObject.transform.localPosition;
		temp.x += 10.0F;
		this.gameObject.transform.localPosition = temp;
	}

	public void RotateRight () {
		Vector3 temp = this.gameObject.transform.localPosition;
		temp.x -= 10.0F;
		this.gameObject.transform.localPosition = temp;
	}
}
