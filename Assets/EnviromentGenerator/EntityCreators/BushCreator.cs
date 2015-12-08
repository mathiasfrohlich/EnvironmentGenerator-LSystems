using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BushCreator : EntityCreator
{
	
	public List<GameObject> bushesRandomPick = new List<GameObject>();
	
    public override GameObject create(Vector3 position)
    {
        int randomInt = (int)Random.Range(0,bushesRandomPick.Count-1+0.99f);
		
		GameObject bushEntiry = Instantiate(bushesRandomPick[randomInt],position,new Quaternion()) as GameObject;
		bushEntiry.name = "BushEntity";
		
		return bushEntiry;
    }

    public override void setUp()
    {
        
    }

    public override void tearDown()
    {
        
    }
}
