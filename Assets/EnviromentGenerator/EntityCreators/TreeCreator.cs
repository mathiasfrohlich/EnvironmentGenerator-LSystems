using UnityEngine;
using System.Collections;

public class TreeCreator : EntityCreator{

    private PersonalLSystem _personalSystem;
    private DrawTree _drawTree;
    //private GameObject totalTree;
    private GameObject goBranch;

    public override GameObject create (Vector3 position)
	{
        _personalSystem = new PersonalLSystem();
        _drawTree = new DrawTree();
        //DrawTree
        //totalTree = new GameObject();
        //_personalSystem = gameObject.GetComponent<PersonalLSystem>();
        goBranch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        CreateBranch();

        Debug.Log("Create Tree");
        /*GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
		capsule.transform.position = position;*/
        /*if (totalTree != null)
            DestroyImmediate(totalTree);*/
        //CreateTree(_personalSystem.CreateTreeStructure());
        //_personalSystem.axiom = "0";
        GameObject tmpTree = _drawTree.CreateTree(_personalSystem.CreateTreeStructure(), position, goBranch);
        //DestroyImmediate(GameObject.FindGameObjectWithTag("Source"));
        
        tmpTree.tag = "Placed Tree";
        return tmpTree;
    }
    void Start()
    {
        
    }
    private void CreateBranch()
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
    }
}