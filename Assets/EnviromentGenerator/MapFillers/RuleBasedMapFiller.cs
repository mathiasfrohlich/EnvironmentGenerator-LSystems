using UnityEngine;
using System.Collections.Generic;

public class RuleBasedMapFiller : MapFiller
{
	
	//public int edgeNumber = 0;
	
	
	public enum edge {Random, Nothing, Grass, Bush, Tree};
	public edge SelectEdgeType;

    public override List<List<int>> fill(List<List<int>> map)
    {
		//Rule : once neightbor can only be 1 higher or lower.
		//If zero it can be zero and 1
		//If 1 it can be zero,1 and 2
		//If 2 it can be 1,2 and 3
		//If 3 if can be 2 and 3
		
        for(int y = 0 ; y < map.Count ; y ++){
			for(int x = 0 ; x < map[y].Count ; x ++){
		
				if(y > 0 && y < map.Count-1  && x > 0 && x < map[y].Count-1){
					// Debug.Log(map[y-1][x] + " max:"+Mathf.Max(0,map[y-1][x]-1) + " min:"+Mathf.Min(3+0.99f,map[y-1][x]+1+0.99f));
					map[y][x] = (int)Random.Range(Mathf.Max(0,map[y-1][x]-1),Mathf.Min(3+0.99f,map[y-1][x]+1+0.99f));
					// Debug.Log(map[y][x]);
				}	
				else{
					if(SelectEdgeType == edge.Random)
						map[y][x] = (int)Random.Range(0.0f,3.99f);	
					else if(SelectEdgeType == edge.Grass)
						map[y][x] = 1;
					else if(SelectEdgeType == edge.Bush)
						map[y][x] = 2;
					else if(SelectEdgeType == edge.Tree)
						map[y][x] = 3;
					else
						map[y][x] = 0;
					//map[y][x] = edgeNumber;//(int)Random.Range(0.0f,3.99f);	
				}
			}
		}
		Debug.Log("Build Rule based random");
		return map;
    }
}
