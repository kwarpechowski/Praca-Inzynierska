using UnityEngine;
using System.Collections;

public class MoveSample : MonoBehaviour
{	
	Hashtable ht = new Hashtable();

	Vector3[] list = new Vector3[]{new Vector3(1,2,3), new Vector3(2,1,3), new Vector3(3,2,1)};
	
	void Awake(){
		ht.Add("path",list);
		ht.Add("time",4);
		ht.Add("delay",1);
		ht.Add("onupdate","myUpdateFunction");
		ht.Add("looptype",iTween.LoopType.loop);
	}

	void Start(){
		iTween.MoveTo(gameObject, ht);
	}
}


