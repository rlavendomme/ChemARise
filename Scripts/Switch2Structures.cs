using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2Children : MonoBehaviour
{
	public GameObject parent;

	public void SwitchTwo()
	{
		int activeIndex = 0;
		int inactiveIndex = 1;
		if (parent.transform.GetChild(0).gameObject.activeInHierarchy)
		{ 
		activeIndex=0;
		inactiveIndex=1;
		}
		else if (parent.transform.GetChild(1).gameObject.activeInHierarchy)
		{ 
		activeIndex=1;
		inactiveIndex=0;
		}
		parent.transform.GetChild(inactiveIndex).gameObject.transform.position = parent.transform.GetChild(activeIndex).gameObject.transform.position;
		parent.transform.GetChild(inactiveIndex).gameObject.transform.localRotation = parent.transform.GetChild(activeIndex).gameObject.transform.localRotation;
		parent.transform.GetChild(inactiveIndex).gameObject.transform.localScale = parent.transform.GetChild(activeIndex).gameObject.transform.localScale;
		parent.transform.GetChild(activeIndex).gameObject.SetActive(false);
		parent.transform.GetChild(inactiveIndex).gameObject.SetActive(true);
	}
}
