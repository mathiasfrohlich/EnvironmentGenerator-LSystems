using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PureRandomMapFiller : MapFiller {
	
    public override List<List<int>> fill(List<List<int>> map)
    {
        for(int y = 0 ; y < map.Count ; y ++){
			for(int x = 0 ; x < map[y].Count ; x ++){	
				map[y][x] = (int)Random.Range(0.0f,3.99f);	
			}
		}
		return map;
    }
}
