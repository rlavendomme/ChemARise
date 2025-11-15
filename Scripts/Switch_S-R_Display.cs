using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_SR_Display : MonoBehaviour
{
    public GameObject[] hide;
    public GameObject[] show;

    public void SwitchSRDisplay()
    {
		foreach(GameObject hide_k in hide)
		{
			if (hide_k.activeInHierarchy)
			{
				foreach(GameObject show_k in show){
					show_k.transform.position = hide_k.transform.position;
					show_k.transform.localRotation = hide_k.transform.localRotation;
					show_k.transform.localScale = hide_k.transform.localScale;
				}
				hide_k.SetActive(false);
			}
		}
		foreach(GameObject show_k in show)
		{
			show_k.SetActive(true);
		}
    }
}
