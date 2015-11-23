using UnityEngine;
using System.Collections;

public class GrassCreator : EntityCreator{

	public override GameObject create (Vector3 position)
	{
		Debug.Log("Create Grass");
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);
		capsule.transform.position = position;

		return capsule;
	}
}
