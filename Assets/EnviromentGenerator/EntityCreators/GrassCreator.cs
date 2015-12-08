using UnityEngine;
using System.Collections;

public class GrassCreator : EntityCreator{

	public GameObject DefaultGrass;

	public float spreadOfGrass = 0.8f;
	
	public int randomAmountUpTo = 4;

	public override GameObject create (Vector3 position)
	{
		GameObject parrent = new GameObject("GrassParrent");
		parrent.transform.position = position;

		int randomAmount = (int)Random.Range(1.0f,randomAmountUpTo + 0.99f);
		for (int i = 0; i < randomAmount; i++)
		{
			Vector3 newOffsetPosition;
			float newX = position.x + Random.Range(spreadOfGrass * -1,spreadOfGrass);
						
			float newZ = position.z + Random.Range(spreadOfGrass * -1,spreadOfGrass);
			
			float newY;
			if(gameObject.GetComponent<Terrain>() != null)
			 	newY = Terrain.activeTerrain.SampleHeight(new Vector3(newX,position.y,newZ));
			else 
				newY = position.y;
			
			newOffsetPosition = new Vector3(newX,newY,newZ);
			
			GameObject grassEntity = Instantiate(DefaultGrass,newOffsetPosition,new Quaternion()) as GameObject;
			grassEntity.name = "GrassEntity";
			grassEntity.transform.parent = parrent.transform;
		}
		
		return parrent;
	}

	public override void setUp ()
	{

	}

	public override void tearDown ()
	{

	}
}
