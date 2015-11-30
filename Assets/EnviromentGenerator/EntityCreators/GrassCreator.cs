using UnityEngine;
using System.Collections;

public class GrassCreator : EntityCreator{

	public GameObject DefaultGrass;

	public override GameObject create (Vector3 position)
	{

		GameObject grassEntity = Instantiate(DefaultGrass,position,new Quaternion()) as GameObject;

		grassEntity.name = "GrassEntity";

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

		return grassEntity;
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
