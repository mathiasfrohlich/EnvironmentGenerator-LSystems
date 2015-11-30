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

	
	public override void setUp ()
	{
		//Use to set up something before creation
	}
	
	public override void tearDown ()
	{
		//Use to teatdown after creation
	}
}
