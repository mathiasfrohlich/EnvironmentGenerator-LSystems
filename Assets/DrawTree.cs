using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawTree : MonoBehaviour {

    private GameObject totalTree;
    private GameObject parent;
    public int turnDegrees = 45;
    private int rot = 45;
    private List<List<Vector3>> posAndAngle = new List<List<Vector3>>();
    private int currentPushes = 0;
    private bool angleHasChanged = false;
    private PersonalLSystem _personalSystem;
    private Vector3 offset = new Vector3(0, 1, 0);
	// Use this for initialization
	void Start () {
        totalTree = new GameObject();
        _personalSystem = gameObject.GetComponent<PersonalLSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
            CreateTree(_personalSystem.CreateTreeStructure());
        }
    }
    public void CreateTree(string structure) {
        for (int i = 0; i < structure.Length; i++) {
            //print("Structe length: " + structure.Length);
            string tmpString = structure.Substring(i, 1);
            switch (tmpString)
            {
                case "0": //Creating a branch with end leaf and assigning them to the parent
                    {
                        GameObject branch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        branch.transform.position = parent.transform.position;
                        branch.transform.Rotate(branch.transform.rotation.eulerAngles.x, branch.transform.rotation.eulerAngles.y, rot);
                        branch.transform.position = parent.transform.position + parent.transform.up;
                        //branch.transform.Translate(branch.transform.position + (branch.transform.localPosition * 0.5f));
                        branch.transform.parent = parent.transform;
                        GameObject leaf = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        //leaf.transform.position = branch.transform.position;
                        
                        leaf.transform.Translate(branch.transform.position + (branch.transform.up * 0.5f));
                        leaf.transform.rotation = branch.transform.rotation;
                        leaf.transform.parent = branch.transform;
                        break;
                    }
                case "1":
                    {
                        GameObject branch = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        if (parent == null) { //Used first time as parent is empty
                            parent = branch.gameObject;
                        }
                        //branch.transform.position = parent.transform.position + offset;
                        //branch.transform.Rotate(branch.transform.rotation.eulerAngles.x, branch.transform.rotation.eulerAngles.y, branch.transform.rotation.eulerAngles.z);
                        //branch.transform.rotation = parent.transform.rotation;
                        if (angleHasChanged && posAndAngle.Count > 0)
                        {
                            angleHasChanged = false;
                            branch.transform.Rotate(posAndAngle[currentPushes - 1][1], Space.Self);
                        }
                        else {
                            branch.transform.rotation = parent.transform.rotation;
                        }
                        branch.transform.position = parent.transform.position;
                        branch.transform.Translate((branch.transform.up));
                        branch.transform.parent = parent.transform;
                        parent = branch.gameObject;
                        break;
                    }
                case "[":
                    {
                       // print("[, pushes: " + currentPushes);
                        rot = Random.Range(rot-turnDegrees, rot+turnDegrees); //Turn left
                        List<Vector3> values = new List<Vector3>();
                        values.Add(parent.transform.position); //Stores position
                        values.Add(new Vector3(parent.transform.localEulerAngles.x, parent.transform.localEulerAngles.y, rot)); //Stores rotation
                        posAndAngle.Add(values);
                        currentPushes++;
                        angleHasChanged = true;
                        break;
                    }
                case "]":
                    {
                        //print("], pushes: " + currentPushes);
                        posAndAngle.RemoveAt(currentPushes-1);
                        currentPushes--;
                        rot += rot; //Turn right
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
       
    }
    private void RotateBranch(GameObject child, GameObject parent) {
        
    }
}
