using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonalLSystemMat : MonoBehaviour {

    private List<string> variables = new List<string>();
    private List<string> constants = new List<string>();
    public string axiom;
    private string rule1, rule2;
    private int recur = 3; //TODO: value zero gives nullref as parent is null, fix

    //private List<string> totalTreeForm = new List<string>();
    // Use this for initialization
    void Start () {
        variables.Add("0");
        variables.Add("1");
        constants.Add("[");
        constants.Add("]");
        axiom = "0";
        rule1 = "11"; //if number is 1 -> 11
        rule2 = "1[0]0"; //if number is 0 -> 1[0]0
		Debug.Log("Run");
        Debug.Log(CreateTreeStructure());
    }
	
	// Update is called once per frame
	void Update () {


	}
	public void CreateEnity(Vector3 position){
		Debug.Log(CreateTreeStructure());
	}

    public string CreateTreeStructure() {
        for (int i = 0; i < recur; i++) { //Runs the number of chosen iterations
            string tmpAxiom = "";
            for (int j = 0; j < axiom.Length; j++) { //Runs dependend on the size of current tree
                string tmpString = axiom.Substring(j, 1);
                switch (tmpString) {
                    case "0": {
                            tmpAxiom += rule2;
                            break;
                        }
                    case "1":
                        {
                            tmpAxiom += rule1;
                            break;
                        }
                    case "[":
                        {
                            tmpAxiom += "[";
                            break;
                        }
                    case "]":
                        {
                            tmpAxiom += "]";
                            break;
                        }
                    default: {
                            Debug.LogError("Wrong string in tree structre: " + tmpString);
                            break;
                        }
                }
            }
            axiom = tmpAxiom;
        }
        print("Axiom: " + axiom);
        return axiom;
    }
}
