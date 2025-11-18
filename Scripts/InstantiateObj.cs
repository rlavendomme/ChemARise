using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObj : MonoBehaviour
{
	public GameObject[] instantiate;
	public int indexShow;
	public GameObject parent;

	public void ShowSingle()
	{
		parent.SetActive(false);
		for (int i = 0; i < instantiate.Length; i++)
		{
			GameObject obj = Instantiate(instantiate[i], parent.transform);
			if(i != indexShow)
			{
				obj.SetActive(false);
			}
		}
		parent.SetActive(true);
	}
	
	public void ShowAll()
	{
		parent.SetActive(false);
		for (int i = 0; i < instantiate.Length; i++)
		{
			GameObject obj = Instantiate(instantiate[i], parent.transform);
		}
		parent.SetActive(true);
	}
}