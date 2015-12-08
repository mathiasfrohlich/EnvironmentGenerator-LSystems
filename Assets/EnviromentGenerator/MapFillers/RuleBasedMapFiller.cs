using UnityEngine;
using System.Collections.Generic;

public class RuleBasedMapFiller : MapFiller
{
	
	//public int edgeNumber = 0;
	
	
	public enum edge {Random, Nothing, Green, Yellow, Blue};
	public edge SelectEdgeType = edge.Random;

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
					//float neightborValue = (map[y-1][x] + map[y+1][x] + map[y][x-1] + map[y][x+1])/4; 
					//Debug.Log(neightborValue +" "+ map[y-1][x] +" "+ map[y+1][x] +" "+ map[y][x-1] +" "+ map[y][x+1]);
					
					//map[y][x] = (int)Random.Range(Mathf.Max(0,neightborValue - 1),Mathf.Min(3+0.99f,neightborValue +1 +0.99f));
					map[y][x] = (int)Random.Range(Mathf.Max(0,map[y-1][x]-1),Mathf.Min(3+0.99f,map[y-1][x]+1+0.99f));
					// Debug.Log(map[y][x]);
				}	
				else{
					if(SelectEdgeType == edge.Random)
						map[y][x] = (int)Random.Range(0.0f,3.99f);	
					else if(SelectEdgeType == edge.Green)
						map[y][x] = 1;
					else if(SelectEdgeType == edge.Yellow)
						map[y][x] = 2;
					else if(SelectEdgeType == edge.Blue)
						map[y][x] = 3;
					else
						map[y][x] = 0;
					//map[y][x] = edgeNumber;//(int)Random.Range(0.0f,3.99f);	
				}
			}
		}
		Debug.Log("Rule based Map filler");
		return map;
    }
}
