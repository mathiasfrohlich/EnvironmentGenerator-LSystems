using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeightedMapFiller : MapFiller {

	[Range(0, 100)]
	public int nothingWeigth;
	[Range(0, 100)]
	public int greenWeigth;
	[Range(0, 100)]
	public int yellowWeigth;
	[Range(0, 100)]
	public int blueWeigth;

    public override List<List<int>> fill(List<List<int>> map)
    {
        for(int y = 0 ; y < map.Count ; y ++){
			for(int x = 0 ; x < map[y].Count ; x ++){	
				float randomNumber = Random.Range(0,nothingWeigth + greenWeigth + yellowWeigth + blueWeigth);
				map[y][x] = getNumber(randomNumber);	
			}
		}
		//Debug.Log("Weighte Map filler");
		return map;
    }
	private int getNumber(float randomNumber){
		int nothingWeigthMin = 0;
		int nothingWeigthMax = nothingWeigth;
		if(randomNumber >= nothingWeigthMin && randomNumber < nothingWeigthMax)
			return 0;
			
		int greenWeigthMin = nothingWeigth;
		int greenWeigthMax = nothingWeigth + greenWeigth;
		if(randomNumber >= greenWeigthMin && randomNumber < greenWeigthMax)
			return 1;
			
		int yellowWeigthMin = nothingWeigth + greenWeigth;
		int yellowWeigthMax = nothingWeigth + greenWeigth + yellowWeigth;
		if(randomNumber >= yellowWeigthMin && randomNumber < yellowWeigthMax)
			return 2;
			
		int blueWeigthMin = nothingWeigth + greenWeigth + yellowWeigth;
		int blueWeigthMax = nothingWeigth + greenWeigth + yellowWeigth + blueWeigth;
		if(randomNumber >= blueWeigthMin && randomNumber < blueWeigthMax)
			return 3;
			
		return 0;
		
	}
}
