using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileButton : MonoBehaviour
{
    public GameObject savePage; 
    public GameObject SaveButton;
    
    bool isQuizSolved = true;

    void Start()
    {
        savePage.SetActive(false);
    }

    public void turnToSavePage(){
        if(isQuizSolved) savePage.SetActive(true);
    }
}

