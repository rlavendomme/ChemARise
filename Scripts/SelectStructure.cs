using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select1Child : MonoBehaviour
{
	public GameObject parent;
	public int selectIndex;

	public void SelectOne()
	{
		int children = parent.transform.childCount;
		int activeIndex=0;
		for(int i=0; i<children; i++)
		{
			if (parent.transform.GetChild(i).gameObject.activeInHierarchy)
			{
				activeIndex = i;
			}
		}
		if (selectIndex!=activeIndex)
		{
			parent.transform.GetChild(selectIndex).gameObject.transform.position = parent.transform.GetChild(activeIndex).gameObject.transform.position;
			parent.transform.GetChild(selectIndex).gameObject.transform.localRotation = parent.transform.GetChild(activeIndex).gameObject.transform.localRotation;
			parent.transform.GetChild(selectIndex).gameObject.transform.localScale = parent.transform.GetChild(activeIndex).gameObject.transform.localScale;
			parent.transform.GetChild(activeIndex).gameObject.SetActive(false);
			parent.transform.GetChild(selectIndex).gameObject.SetActive(true);
		}
	}
}
