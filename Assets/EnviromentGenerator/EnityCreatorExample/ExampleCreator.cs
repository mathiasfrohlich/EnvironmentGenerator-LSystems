using UnityEngine;
using System.Collections;

public class ExampleCreator : EntityCreator{

	public override GameObject create (Vector3 position)
	{
		Debug.Log("Create Example");
		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		capsule.transform.position = position;

		return capsule;
	}
}
