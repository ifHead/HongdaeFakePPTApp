using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPage : MonoBehaviour
{
    public GameObject inputFields;

    void Update()
    {
        if(SlideChanger.isPageInput)
        {
            inputFields.SetActive(true);
        }
        else
        {
            inputFields.SetActive(false);
        }
    }
}
