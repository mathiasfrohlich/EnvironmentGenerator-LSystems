using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FillArea : MonoBehaviour {

    private LSystemsD _lsystem;
    public GameObject area;
    public List<Transform> treePos = new List<Transform>();
	// Use this for initialization
	void Start () {
        _lsystem = gameObject.GetComponent<LSystemsD>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            int num = 0;
            foreach (Transform pos in treePos) {
                _lsystem.ClearLists();
                ResetTree();
                RandomizeNumbers();
                _lsystem.CreateTree();

                _lsystem.theTree.transform.parent = area.transform;
                _lsystem.theTree.transform.position = treePos[num].position;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Destroy(_lsystem.theTree);
        }
	}
    private void RandomizeNumbers() {
        _lsystem.segBottomRadius = Random.Range(0.1f, 1);
        _lsystem.segTopRadius = Random.Range(0.1f, 1);
        _lsystem.segLength = Random.Range(1f, 3f);
        //_lsystem.segLength = Random.Range(0.1f, 0.5f); //"Bushes"
        print("Buttom: " + _lsystem.segBottomRadius);
        print("Top: " + _lsystem.segTopRadius);
        print("Length: " + _lsystem.segLength);
    }
    private void ResetTree() {
        if (_lsystem.theTree != null) {
            print("Reset");
            Destroy(_lsystem.theTree);
            _lsystem.plant.Clear();
        }
    }
}
