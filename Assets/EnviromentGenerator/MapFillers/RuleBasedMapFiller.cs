using UnityEngine;
using System.Collections.Generic;

public class RuleBasedMapFiller : MapFiller
{
    public override List<List<int>> fill(List<List<int>> map)
    {
		//Rule : once neightbor can only be 1 higher or lower.
		
        for(int y = 0 ; y < map.Count ; y ++){
			for(int x = 0 ; x < map[y].Count ; x ++){	
				map[y][x] = (int)Random.Range(0.0f,3.99f);	
			}
		}
		Debug.Log("Test");
		return map;
    }
}
