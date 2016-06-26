using UnityEngine;
using System.Collections;

public class Rura : MonoBehaviour {
	private bool upAction = false;
	private bool downAction = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.gameObject.GetComponent<Animator> ();
		NetworkManager.StartListening ("up", UpEvent);
		NetworkManager.StartListening ("down", DownEvent);
	}

	void OnDisable ()
	{
		NetworkManager.StopListening ("up", UpEvent);
		NetworkManager.StopListening ("down", DownEvent);
	}

	void UpEvent () {
		upAction = true;
	}

	void DownEvent () {
		downAction = true;
	}

	public void Run() {
		animator.SetTrigger("Run");
	}

	
	// Update is called once per frame
	void Update () {
		if (upAction) {
			Up ();
			upAction = false;
		}

		if (downAction) {
			Down ();
			downAction = false;
		}
	}


	public void Up() {
		Debug.Log ("w gore");
		Vector3 temp = this.gameObject.transform.localPosition;
		temp.y += 10;
		this.gameObject.transform.localPosition = temp;
	}

	public void Down() {
		Debug.Log ("w dol");
		Vector3 temp = this.gameObject.transform.localPosition;
		temp.y -= 10;
		this.gameObject.transform.localPosition = temp;
	}
}
