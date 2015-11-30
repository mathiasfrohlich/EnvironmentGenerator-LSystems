using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawTree : MonoBehaviour {

    private GameObject totalTree;
    private GameObject parent;
    public int turnDegrees = 30;
    private int rot = 30, rot2 = 30, rot3 = 30;
    //private List<List<Vector3>> posAndAngle = new List<List<Vector3>>();
    private List<ParentAtSplit> splitParents = new List<ParentAtSplit>();
    private int currentPushes = 0;
    private bool angleHasChanged = false;
    private PersonalLSystem _personalSystem;
    private Vector3 offset = new Vector3(0, 1, 0);
    //private GameObject goBranch;
	// Use this for initialization
	/*void Start () {
        totalTree = new GameObject();
        _personalSystem = gameObject.GetComponent<PersonalLSystem>();
        goBranch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        CreateBranch();
    }*/
	
	// Update is called once per frame
	/*void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            if (totalTree != null)
                DestroyImmediate(totalTree);
            CreateTree(_personalSystem.CreateTreeStructure(), Vector3.zero);
            _personalSystem.axiom = "0";
        }
    }*/
    /*private void CreateBranch() {
        GameObject top = new GameObject();
        GameObject low = new GameObject();
        top.name = "TopPos";
        low.name = "LowPos";

        top.transform.position = new Vector3(goBranch.transform.position.x, goBranch.transform.position.y + 1, goBranch.transform.position.z);
        low.transform.position = new Vector3(goBranch.transform.position.x, goBranch.transform.position.y - 1, goBranch.transform.position.z);
        top.transform.parent = goBranch.transform;
        low.transform.parent = goBranch.transform;

        //return go;
    }*/
    public GameObject CreateTree(string structure, Vector3 treePosition, GameObject goBranch) {
        for (int i = 0; i < structure.Length; i++) {
            //print("Structe length: " + structure.Length);
            string tmpString = structure.Substring(i, 1);
            switch (tmpString)
            {
                case "0": //Creating a branch with end leaf and assigning them to the parent
                    {
                        GameObject branch = GameObject.Instantiate(goBranch) as GameObject; //GameObject branch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        branch.transform.position = parent.transform.FindChild("TopPos").position; //branch.transform.position = parent.transform.position;
                        branch.transform.rotation = parent.transform.rotation;    //branch.transform.Rotate(branch.transform.rotation.eulerAngles.x, branch.transform.rotation.eulerAngles.y, rot);
                        branch.transform.position = branch.transform.position + branch.transform.up;
                        branch.transform.parent = parent.transform;
                        branch.name = "EndBranch";
                        GameObject leaf = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        leaf.transform.localScale /= 2;
                        //leaf.transform.position = branch.transform.position;
                        leaf.transform.position = branch.transform.FindChild("TopPos").position;
                        //leaf.transform.position = leaf.transform.position + new Vector3(0, leaf.transform.localScale.y,0) ;
                        leaf.name = "Leaf";
                        leaf.transform.rotation = branch.transform.rotation;
                        //leaf.transform.position += (leaf.transform.up);
                        leaf.transform.parent = branch.transform;
                        if (currentPushes > 0) { //sets the parent to the previos parent when we have finish a node
                            parent = splitParents[currentPushes - 1].splitParent;
                        }
                        
                        break;
                    }
                case "1":
                    {
                        GameObject branch = GameObject.Instantiate(goBranch) as GameObject; //GameObject branch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        branch.name = "Branch";
                        if (parent == null) { //Used first time as parent is empty
                            parent = branch.gameObject;
                            branch.tag = "Tree";
                            branch.name = "Tree";
                            branch.transform.position = treePosition;
                            //parent.transform.position = treePosition;
                        }
                        //branch.transform.position = parent.transform.position + offset;
                        //branch.transform.Rotate(branch.transform.rotation.eulerAngles.x, branch.transform.rotation.eulerAngles.y, branch.transform.rotation.eulerAngles.z);
                        //branch.transform.rotation = parent.transform.rotation;
                        if (angleHasChanged && splitParents.Count > 0)
                        {
                            angleHasChanged = false;
                            //branch.transform.Rotate(posAndAngle[currentPushes - 1][1], Space.Self);
                            branch.transform.Rotate(splitParents[currentPushes - 1].rot, Space.Self);
                        }
                        else {
                            branch.transform.rotation = parent.transform.rotation;
                        }
                        branch.transform.position = parent.transform.FindChild("TopPos").position;
                        //branch.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z); //+1 is height of capsulecoliider (get height if nessesary)
                        //Debug.DrawRay(branch.transform.position, );
                        Debug.DrawLine(branch.transform.position, branch.transform.position+ parent.transform.up, Color.green, 10);
                        branch.transform.position += branch.transform.up;
                        //branch.transform.Translate((branch.transform.up));
                        branch.transform.parent = parent.transform;
                        parent = branch.gameObject;
                        break;
                    }
                case "[":
                    {
                        // print("[, pushes: " + currentPushes);
                        rot = Random.Range(rot-turnDegrees, rot+turnDegrees); //Turn left
                        rot2 = Random.Range(rot2 - turnDegrees, rot2 + turnDegrees); //Turn y axis
                        rot3 = Random.Range(rot3 - turnDegrees, rot3 + turnDegrees); //Turn x axis
                        /*List<Vector3> values = new List<Vector3>();
                        values.Add(parent.transform.position); //Stores position
                        values.Add(new Vector3(parent.transform.localEulerAngles.x, parent.transform.localEulerAngles.y, rot)); //Stores rotation*/
                        ParentAtSplit tmpParent = new ParentAtSplit();
                        tmpParent.splitParent = parent;
                        tmpParent.rot = new Vector3(rot3, rot2, rot);
                        splitParents.Add(tmpParent);
                        currentPushes++;
                        angleHasChanged = true;
                        break;
                    }
                case "]":
                    {
                        //print("], pushes: " + currentPushes);
                        splitParents.RemoveAt(currentPushes-1);
                        currentPushes--;
                        rot += rot; //Turn right
                        rot2 += rot2; //Turn y axis
                        rot3 += rot3; //Turn x axis
                        angleHasChanged = true;
                        break;
                    }
                default:
                    {
                        Debug.LogError("Wrong string in tree structre: " + tmpString);
                        break;
                    }
            }
        }
        totalTree = GameObject.FindGameObjectWithTag("Tree");
        //DestroyImmediate(GameObject.FindWithTag("Source").gameObject);
        parent = null;
        angleHasChanged = false;
        //Debug.Log("Splitparents should be 0: " + splitParents.Count + " and currentpushes should be 0: "  + currentPushes);
        return totalTree;
    }
}
public class ParentAtSplit : MonoBehaviour{
    public GameObject splitParent;
    public Vector3 rot;
}
