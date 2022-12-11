using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLoadingBar : MonoBehaviour
{
    public Transform bar;
    float x = 0;
    public static bool gameEnd = false;

    private void Update()
    {
        bar.localScale = new Vector3(x, 1, 1);
        x += Random.Range(0,0.06f);
        if(x>30){x=30;}
    }

    private void OnEnable()
    {
        gameEnd = true;
    }
}
