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


//		Debug.Log("Create Grass");
//		GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);
//		capsule.transform.position = position;
//
//
//		Terrain t = gameObject.GetComponent<Terrain>();
//
//		float threshold = 0.5f;
//
//		DetailMapCutoff(t,threshold);


//		gameObject.GetComponent<Terrain>().terrainData.SetDetailLayer(position.x,position.y,LayerMask.GetMask("Default"))

		return parrent;
	}

	public override void setUp ()
	{

	}

	public override void tearDown ()
	{

	}

	// Set all pixels in a detail map below a certain threshold to zero.
	public void DetailMapCutoff(Terrain t, float threshold) {
//		// Get all of layer zero.
//		var map = t.terrainData.GetDetailLayer(0, 0, t.terrainData.detailWidth, t.terrainData.detailHeight, 0);
//		
//		// For each pixel in the detail map...
//		for (var y = 0; y < t.terrainData.detailHeight; y++) {
//			for (var x = 0; x < t.terrainData.detailWidth; x++) {
//				// If the pixel value is below the threshold then
//				// set it to zero.
//				Debug.Log(map[x,y]);
//
//				if (map[x, y] < threshold) {
//					map[x, y] = 0;
//				}
//			}
//		}
//		
//		// Assign the modified map back.
//		t.terrainData.SetDetailLayer(0, 0, 0, map);
	}
}
