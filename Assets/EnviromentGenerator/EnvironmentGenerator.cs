using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentGenerator : MonoBehaviour {

	public bool showGrid = true;
	
	public MapFiller mapFiller;

	public int sizeX = 10;
	public int sizeY = 10;
	
	public EntityCreator greenEntity;
	
	public EntityCreator yellowEntity;

	public EntityCreator blueEntity;



	
	public List<List<int>> map;


	[HideInInspector]
	public GameObject parent;

	[HideInInspector]
	public GameObject control1Obj;
	[HideInInspector]
	public GameObject control2Obj;

	[HideInInspector]
	public Vector3 lastPos;

	Vector3 tempCon1;
	Vector3 tempCon2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void initMap(int xSize, int ySize){
		map = new List<List<int>>();

		for(int y = 0 ; y < ySize ; y ++){
			List<int> temp = new List<int>();
			for(int x = 0 ; x < xSize ; x ++){	
				temp.Add(0);
			}
			map.Add(temp);
		}
	}

	public void printMap(List<List<int>> map){
		string s = "";
		for(int y = 0 ; y < map.Count ; y ++){
			for(int x = 0 ; x < map[y].Count ; x ++){	
				s =  s + map[y][x].ToString();	
			}
			s = s + "\n";
		}
		Debug.Log(s);
	}

	public void fillRandom(List<List<int>> map){
		// for(int y = 0 ; y < map.Count ; y ++){
		// 	for(int x = 0 ; x < map[y].Count ; x ++){	
		// 		map[y][x] = (int)Random.Range(0.0f,3.99f);	
		// 	}
		// }
		map = mapFiller.fill(map);
	}

	void OnDrawGizmos() {

		if(control1Obj != null){
			Gizmos.DrawSphere(control1Obj.transform.position,0.3f);
			Gizmos.DrawSphere(control2Obj.transform.position,0.3f);
		if (showGrid)
				DebugDrawGrid(control1Obj.transform.position,control2Obj.transform.position);
		
			if(map != null)
				DebugDrawColors(control1Obj.transform.position,control2Obj.transform.position);
		}


	}
	
	public void DebugDrawGrid(Vector3 control1, Vector3 control2) {



		float width = control2.x - control1.x;
		float height =  control2.z - control1.z;
		// Draw the horizontal grid lines
		for (int i = 0; i < sizeY + 1; i++) {
			Vector3 step = i * (new Vector3(0.0f, 0.0f, 1.0f) / sizeY);
			Vector3 startPos = control1 + step * height; 
			Vector3 endPos = startPos + width * new Vector3(1.0f, 0.0f, 0.0f);
			Gizmos.color = new Color(1,1,1,0.3f);
			Gizmos.DrawLine(startPos, endPos);
			//Debug.DrawLine(startPos, endPos, color,0,true);
		}
		//Draw the vertial grid lines
		for (int i = 0; i < sizeX + 1; i++) {
			Vector3 step = i * (new Vector3(1.0f, 0.0f, 0.0f) / (sizeX));
			Vector3 startPos = control1 + step * width;
			Vector3 endPos = startPos + height * new Vector3(0.0f, 0.0f, 1.0f);
			Gizmos.color = new Color(1,1,1,0.3f);
			Gizmos.DrawLine(startPos, endPos);

			//Debug.DrawLine(startPos, endPos, color,0,true);
		}

		if(gameObject.GetComponent<Terrain>() != null){

			if(gameObject.GetComponent<Terrain>() != null){
				if(!control1Obj.transform.position.Equals(tempCon1)){
					tempCon1 = new Vector3(control1Obj.transform.position.x,Terrain.activeTerrain.SampleHeight(tempCon1),control1Obj.transform.position.z);
					control1Obj.transform.position = tempCon1;
				}
				if(!control2Obj.transform.position.Equals(tempCon2)){
					tempCon2 = new Vector3(control2Obj.transform.position.x,Terrain.activeTerrain.SampleHeight(tempCon2),control2Obj.transform.position.z);
					control2Obj.transform.position = tempCon2;
				}
			}

		}


	} 
	public void DebugDrawColors(Vector3 control1, Vector3 control2){

		if(map.Count != sizeY || map[0].Count != sizeX)
			initMap(sizeX,sizeY);


		float width = control2.x - control1.x;
		float height =  control2.z - control1.z;

		for(int y = 0 ; y < sizeY; y++){
			for (int x = 0; x < sizeX; x++) {
				Vector3 stepX = y * (new Vector3(0.0f, 0.0f, 1.0f) / (sizeY));
				Vector3 startPosX = (stepX * height) + ( (new Vector3(0.0f, 0.0f, 1.0f) / (sizeY) ) * height/2 ); 
				
				Vector3 stepY = x * (new Vector3(1.0f, 0.0f, 0.0f) / (sizeX));
				Vector3 startPosY = (control1 + stepY * width) + ( (new Vector3(1.0f, 0.0f, 0.0f) / (sizeX) ) * width/2 );


				if(map[y][x] == 1)
					Gizmos.color = Color.green;
				else if(map[y][x] == 2)
					Gizmos.color = Color.yellow;
				else if(map[y][x] == 3)
					Gizmos.color = Color.blue;
				else
					Gizmos.color = Color.gray;


				Gizmos.color = new Color(Gizmos.color.r,Gizmos.color.g,Gizmos.color.b,1.5f);


				if(gameObject.GetComponent<Terrain>() != null){
					Vector3 startPosZ = Terrain.activeTerrain.SampleHeight(startPosX+startPosY) * new Vector3(0.0f, 1.0f, 0.0f);
					Gizmos.DrawSphere(startPosX+startPosY + startPosZ,2.0f / ( (sizeX+sizeY)/2) + (Vector3.Distance(control1,control2)/((sizeX+sizeY)*3)));
				}
           		else{
					Gizmos.DrawSphere(startPosX+startPosY,1.0f / ( (sizeX+sizeY)/2)  );
				}
			}
		}
	}

	public void buildMap(List<List<int>> map){

		parent = new GameObject("GeneratedEnviroment");

		List<List<Vector3>> cordinates = new List<List<Vector3>>();

		float width = control2Obj.transform.position.x - control1Obj.transform.position.x;
		float height =  control2Obj.transform.position.z - control1Obj.transform.position.z;
		
		for(int y = 0 ; y < sizeY; y++){
			List<Vector3> tmp = new List<Vector3>();
			for (int x = 0; x < sizeX; x++) {
				Vector3 stepX = y * (new Vector3(0.0f, 0.0f, 1.0f) / (sizeY));
				Vector3 startPosX = (stepX * height) + ( (new Vector3(0.0f, 0.0f, 1.0f) / (sizeY) ) * height/2 ); 
				
				Vector3 stepY = x * (new Vector3(1.0f, 0.0f, 0.0f) / (sizeX));
				Vector3 startPosY = (control1Obj.transform.position + stepY * width) + ( (new Vector3(1.0f, 0.0f, 0.0f) / (sizeX) ) * width/2 );

				if(gameObject.GetComponent<Terrain>() != null){
					Vector3 startPosZ = Terrain.activeTerrain.SampleHeight(startPosX+startPosY) * new Vector3(0.0f, 1.0f, 0.0f);
					tmp.Add(startPosX+startPosY+startPosZ);
				}
				else
					tmp.Add(startPosX+startPosY);
			}
			cordinates.Add(tmp);
		}



		callSetUp(cordinates);



		for(int y = 0 ; y < cordinates.Count ; y ++){
			for(int x = 0 ; x < cordinates[y].Count ; x ++){	
				GameObject gereratedGameObject = null;

				if(map[y][x] == 1){
					if(greenEntity != null){
						gereratedGameObject = greenEntity.create(cordinates[y][x]);
					}
				}
				else if(map[y][x] == 2){
					if(yellowEntity != null){
						gereratedGameObject = yellowEntity.create(cordinates[y][x]);
					}
				}
				else if(map[y][x] == 3){
					if(blueEntity != null){
						gereratedGameObject = blueEntity.create(cordinates[y][x]);
						//gereratedGameObject.GetComponent<Renderer>().material.color = Color.blue;
					}
				}
				else{
					//gereratedGameObject.GetComponent<Renderer>().material.color = Color.gray;
				}
				if(gereratedGameObject != null){
					gereratedGameObject.transform.parent = parent.transform;
					//float size = (2.0f / ( (sizeX+sizeY)/2) + (Vector3.Distance(control1Obj.transform.position,control2Obj.transform.position)/((sizeX+sizeY)*2))) + 0.0f;
					//gereratedGameObject.transform.localScale = new Vector3(size,size,size);
				}

			}
		}


		callTearDown(cordinates);

	}

	void callSetUp(List<List<Vector3>> cordinates){
		for(int y = 0 ; y < cordinates.Count ; y ++)
			for(int x = 0 ; x < cordinates[y].Count ; x ++){	
				
				if(map[y][x] == 1){
					if(greenEntity != null){
						greenEntity.setUp();
					}
				}
				else if(map[y][x] == 2){
					if(yellowEntity != null){
						yellowEntity.setUp();
					}
				}
				else if(map[y][x] == 3){
					if(blueEntity != null){
						blueEntity.setUp();
					}
				}
			}
	}

	void callTearDown(List<List<Vector3>> cordinates){
		for(int y = 0 ; y < cordinates.Count ; y ++)
			for(int x = 0 ; x < cordinates[y].Count ; x ++){	
				
				if(map[y][x] == 1){
					if(greenEntity != null){
						greenEntity.tearDown();
					}
				}
				else if(map[y][x] == 2){
					if(yellowEntity != null){
						yellowEntity.tearDown();
					}
				}
				else if(map[y][x] == 3){
					if(blueEntity != null){
						blueEntity.tearDown();
					}
				}
			}
		
	}

}
