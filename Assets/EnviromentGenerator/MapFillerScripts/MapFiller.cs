using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MapFiller : MonoBehaviour, IMapFilller {

	public abstract List<List<int>> fill(List<List<int>> map);

}