using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersonalLSystem{

    private List<string> variables = new List<string>();
    private List<string> constants = new List<string>();
    public string axiom;
    private string rule1, rule2;
    private int recur = 2; //TODO: value zero gives nullref as parent is null, fix

    //private List<string> totalTreeForm = new List<string>();
    // Use this for initialization
    void Start () {
        variables.Add("0");
        variables.Add("1");
        constants.Add("[");
        constants.Add("]");
        axiom = "0";
        rule1 = "11"; //if number is 1 -> 11
        rule2 = "1[[0]01"; //if number is 0 -> 1[0]0
        //CreateTreeStructure();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    public string CreateTreeStructure() {
        axiom = "0";
        rule1 = "1"; //if number is 1 -> 11
        rule2 = "1[10]10[10[10][10]]10"; //if number is 0 -> 1[0]0         (X → F−[[X]+X]+F[+FX]−X), (F → FF)
        for (int i = 0; i < recur; i++) { //Runs the number of chosen iterations
            string tmpAxiom = "";
            //rule2 += "[0]0]"; //adds another branching each generation
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
        //print("Axiom: " + axiom);
        return axiom;
    }
}
