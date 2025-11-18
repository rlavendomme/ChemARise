using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Release : MonoBehaviour
{
	public GameObject parent;

	public void ReleaseChildren()
	{
		int children = parent.transform.childCount;
		for(int i=0; i<children; i++)
		{
			Addressables.ReleaseInstance(parent.transform.GetChild(i).gameObject);
		}
	}
}
