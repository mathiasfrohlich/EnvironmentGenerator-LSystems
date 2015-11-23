using UnityEngine;
using System.Collections;

public abstract class EntityCreator : MonoBehaviour, IEntityCreator {

	public abstract GameObject create(Vector3 position);
}
