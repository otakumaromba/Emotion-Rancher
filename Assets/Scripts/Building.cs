using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour //abstrato significa que não é instanciável
{

	public abstract bool OnObjectDrop(Draggable draggable);

}
