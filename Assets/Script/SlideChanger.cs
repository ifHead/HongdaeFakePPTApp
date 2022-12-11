using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SlideChanger : MonoBehaviour
{
    public static bool isPageInput = false;
    
    private void Start()
    {
        // Debug.Log(gameObject.name);
        gameObject.GetComponent<Button>().onClick.AddListener(() => {setSlideImgTo();});
    }

    public void setSlideImgTo()
    {
        int open = gameObject.name.IndexOf("(") + 1;
        int close = gameObject.name.IndexOf(")");
        int numLen = close - open;
        // Debug.Log(gameObject.name.Substring(open, numLen));
        int slideNum = int.Parse(gameObject.name.Substring(open, numLen));

        if(slideNum+1 == 27)
        {
            isPageInput = true;
            Invoke("setQuizSolved", 5f);
        }
        else
        {
            isPageInput = false;
            SaveButton.isQuizSolved = false;
        }

        Sprite s = Resources.Load<Sprite>($"Slides/슬라이드{slideNum + 1}");
        GameObject.Find("SlideImage").GetComponent<Image>().sprite = s;
    }

    public void setQuizSolved()
    {
        SaveButton.isQuizSolved = true;
    }

    public void setQuizUnSolved()
    {
        SaveButton.isQuizSolved = false;
    }
}