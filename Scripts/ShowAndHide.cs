using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Hide : MonoBehaviour
{
	public GameObject[] children_hide;
	public GameObject[] children_show;
    public GameObject[] hide;
	public GameObject[] show;

    public void ShowHide()
    { 
		foreach(GameObject hide_k in children_hide)
		{
			int children = hide_k.transform.childCount;
			for(int i=0; i<children; i++)
			{
				hide_k.transform.GetChild(i).gameObject.SetActive(false);
			}
		}		
		foreach(GameObject show_k in children_show)
		{
			int children = show_k.transform.childCount;
			for(int i=0; i<children; i++)
			{
				show_k.transform.GetChild(i).gameObject.SetActive(true);
			}
		}
		foreach(GameObject hide_k in hide)
		{
			hide_k.SetActive(false);
		}
		foreach(GameObject show_k in show)
		{
			show_k.SetActive(true);
		}
    }
}
