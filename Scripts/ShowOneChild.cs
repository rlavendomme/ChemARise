using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOneChild : MonoBehaviour
{
	public int indexShow;
	public GameObject parent;

	public void ShowIndex()
	{
		int children = parent.transform.childCount;
		for (int i = 0; i < children; i++)
		{
			if (i == indexShow)
			{
				parent.transform.GetChild(i).gameObject.SetActive(true);
			}
			else
			{
				parent.transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}