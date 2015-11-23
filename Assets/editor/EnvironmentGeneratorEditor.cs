using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(EnvironmentGenerator))]
public class EnvironmentGeneratorEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();


		EnvironmentGenerator myScript = (EnvironmentGenerator)target;


		if(myScript.control1Obj == null){
			if(GUILayout.Button("Select Area")){
				if(myScript.control1Obj == null){
					myScript.control1Obj = new GameObject("ControlPoint1");
					myScript.control2Obj = new GameObject("ControlPoint2");
					myScript.control2Obj.AddComponent(typeof(MeshRenderer));
					myScript.control2Obj.transform.position = myScript.lastPos;

					SceneView.RepaintAll();

				}
			}
		}
		if(myScript.control1Obj != null){
			if(myScript.map == null){
				if(GUILayout.Button("Initalize Map")){
					myScript.initMap(myScript.sizeX,myScript.sizeY);	
					SceneView.RepaintAll();
				}
			}
			else{
				if(GUILayout.Button("Random Map")){
					myScript.fillRandom(myScript.map);	
					SceneView.RepaintAll();
				}

				if(GUILayout.Button("Build Map")){


					myScript.printMap(myScript.map);

					myScript.buildMap(myScript.map);

					myScript.lastPos = myScript.control2Obj.transform.position;

					DestroyImmediate(myScript.control1Obj);
					DestroyImmediate(myScript.control2Obj);


				}
				if(GUILayout.Button("Reset")){
					myScript.lastPos = myScript.control2Obj.transform.position;
//					myScript.lastPos = new Vector3(1,0,1);
					myScript.map = null;	
					
					DestroyImmediate(myScript.control1Obj);
					DestroyImmediate(myScript.control2Obj);
					SceneView.RepaintAll();
				}
			}
		}
		else{

		}


	} 

}
