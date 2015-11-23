using UnityEngine;
using System.Collections;

public class TreeCreator : EntityCreator{

	public override GameObject create (Vector3 position)
	{
		Debug.Log("Create Tree");
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = position;

		return capsule;
	}
}
