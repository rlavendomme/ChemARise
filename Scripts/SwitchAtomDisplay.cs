using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAtomDisplay : MonoBehaviour
{
    public GameObject sticks;
    public GameObject balls;

    public void SwitchDisplay()
    {

        if (sticks.activeInHierarchy)
        {
            balls.transform.position = sticks.transform.position;
            balls.transform.localRotation = sticks.transform.localRotation;
            balls.transform.localScale = sticks.transform.localScale;
        }
        else if(balls.activeInHierarchy){
            sticks.transform.position = balls.transform.position;
            sticks.transform.localRotation = balls.transform.localRotation;
            sticks.transform.localScale = balls.transform.localScale;
        }
            
        sticks.SetActive(!sticks.activeInHierarchy);
        balls.SetActive(!sticks.activeInHierarchy);
    }
}
