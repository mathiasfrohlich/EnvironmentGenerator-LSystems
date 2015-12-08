﻿using UnityEngine;
using System.Collections;
using System;

public class TreeCreator : EntityCreator{

    private PersonalLSystem _personalSystem;
    private DrawTree _drawTree;
    //private GameObject totalTree;
    public GameObject goBranch, leaf;


    public override void setUp()
    {
        //throw new NotImplementedException();
    }
    public override void tearDown()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Source")) {
            DestroyImmediate(go);
        }
        //throw new NotImplementedException();
    }

    public override GameObject create (Vector3 position)
	{
        _personalSystem = new PersonalLSystem();
        _drawTree = new DrawTree();
        //DrawTree
        //totalTree = new GameObject();
        //_personalSystem = gameObject.GetComponent<PersonalLSystem>();
        //goBranch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        //CreateBranch();
        Debug.Log("Create Tree");
        /*GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = position;*/
        /*if (totalTree != null)
            DestroyImmediate(totalTree);*/
        //CreateTree(_personalSystem.CreateTreeStructure());
        //_personalSystem.axiom = "0";
        GameObject tmpTree = _drawTree.CreateTree(_personalSystem.CreateTreeStructure(), position, goBranch, leaf);
        //DestroyImmediate(GameObject.FindGameObjectWithTag("Source"));
        
        tmpTree.tag = "Placed Tree";
        //MergeMesh(tmpTree);
        //tmpTree.transform.localScale.Set(tmpTree.transform.localScale.x*0.5f, tmpTree.transform.localScale.y*0.5f, tmpTree.transform.localScale.z*0.5f);
        //tmpTree.transform.localScale.Scale(new Vector3(1,1,1), new Vector3(0.5f, 0.5f, 0.5f));
        //tmpTree.transform.localScale /= 2;
        return tmpTree;
    }
    void Start()
    {
        
    }
    private void MergeMesh(GameObject theTree) {
        MeshFilter[] meshFilters = theTree.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }
        theTree.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        theTree.transform.GetComponent<MeshFilter>().sharedMesh.CombineMeshes(combine);
        theTree.transform.gameObject.SetActive(true);
    }
   /* private void CreateBranch()
    {
        GameObject top = new GameObject();
        GameObject low = new GameObject();
        top.name = "TopPos";
        low.name = "LowPos";

        top.transform.position = new Vector3(goBranch.transform.position.x, goBranch.transform.position.y + 1, goBranch.transform.position.z);
        low.transform.position = new Vector3(goBranch.transform.position.x, goBranch.transform.position.y - 1, goBranch.transform.position.z);
        top.transform.parent = goBranch.transform;
        low.transform.parent = goBranch.transform;
        goBranch.tag = "Source";
    }*/
}