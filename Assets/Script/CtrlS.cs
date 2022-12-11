using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlS : MonoBehaviour
{
    public GameObject saveButton;

    void Update()
    {
        if ((Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(KeyCode.S))
        {
            saveButton.GetComponent<SaveButton>().turnToSavePage();
        }
    }
}
