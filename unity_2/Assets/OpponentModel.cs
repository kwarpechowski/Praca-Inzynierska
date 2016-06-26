using UnityEngine;
using System.Collections.Generic;

public class OpponentModel {

	public int Health { get; set; }
	public Vector3 Pos { get; set; }
	public List<Vector3> MovePath = new List<Vector3> ();


	public OpponentModel ()
	{
	}
}


