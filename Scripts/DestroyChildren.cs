using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildren : MonoBehaviour
{
	public GameObject parent;

	public void Destroy()
	{
		int children = parent.transform.childCount;
		for(int i=0; i<children; i++)
		{
			Destroy(parent.transform.GetChild(i).gameObject);
		}
	}
}
