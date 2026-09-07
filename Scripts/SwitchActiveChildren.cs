using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActiveChildren : MonoBehaviour
{
	public GameObject parent;
	public int[] children;
	public int activeIndex;

    public void SwitchDisplay()
    { 
		foreach(int childIndex in children)
		{
			if (parent.transform.GetChild(childIndex).gameObject.activeInHierarchy)
			{
				parent.transform.GetChild(childIndex).gameObject.SetActive(false);
			}
			else
			{
				parent.transform.GetChild(childIndex).gameObject.transform.position = parent.transform.GetChild(activeIndex).gameObject.transform.position;
				parent.transform.GetChild(childIndex).gameObject.transform.localRotation = parent.transform.GetChild(activeIndex).gameObject.transform.localRotation;
				parent.transform.GetChild(childIndex).gameObject.transform.localScale = parent.transform.GetChild(activeIndex).gameObject.transform.localScale;
				parent.transform.GetChild(childIndex).gameObject.SetActive(true);
			}
		}
    }
}
