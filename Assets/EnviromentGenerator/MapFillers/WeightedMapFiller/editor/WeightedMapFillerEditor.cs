using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(WeightedMapFiller))]
[CanEditMultipleObjects]
public class WeightedMapFillerEditor : Editor {

	public override void OnInspectorGUI(){
		
		DrawDefaultInspector();


		WeightedMapFiller myScript = (WeightedMapFiller)target;
		
		Rect r = EditorGUILayout.BeginVertical();
		
		 Rect nothingRect = GUILayoutUtility.GetRect(0,20);
		 Rect greenRect = GUILayoutUtility.GetRect(0,20);
		
		float greenProgress = ((float)myScript.greenWeigth/100);
		
		
		EditorGUILayout.IntSlider (myScript.nothingWeigth, 0, 100);
		
		EditorGUI.ProgressBar(nothingRect, myScript.nothingWeigth, "Nothing");
		
		
		EditorGUI.ProgressBar(greenRect, greenProgress, "Green");
		
		
		GUILayout.Space(20);
     	EditorGUILayout.EndVertical();
		 
		 
		
		
	}
}
