using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_Hide : MonoBehaviour
{
    public GameObject[] hide;
	public GameObject[] show;

    public void ShowHide()
    { 
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
