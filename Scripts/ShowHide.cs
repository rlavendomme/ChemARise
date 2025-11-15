using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAndHide : MonoBehaviour
{
    public GameObject hide;
	public GameObject show1;
    public GameObject show2;
	public GameObject show3;
	public GameObject show4;

    public void ShowHide()
    { 
        hide.SetActive(false);
        show1.SetActive(true);
		show2.SetActive(true);
		show3.SetActive(true);
		show4.SetActive(true);
    }
}
