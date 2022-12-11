using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    public GameObject savePage;
    public GameObject saveForm;
    public GameObject crashImage;
    public GameObject errorSound;
    public GameObject whiteScreen;
    public GameObject freezeLoading;
    GameObject inputFields;

    float opac = 0;
    public static bool isQuizSolved = false;
    Coroutine FadeCoroutine;
    int errorNum = 15;
    GameObject[] errorImage = new GameObject[15];

    bool errorFlag = false;

    void Start()
    {
        inputFields = GameObject.Find("inputField");
        saveForm.GetComponent<Image>().color = new Color(1,1,1,0);
        for(int i = 0; i < errorNum; i++)
        {
            errorImage[i] = new GameObject();
        }
    }

    public void turnToSavePage()
    {
        if (isQuizSolved) 
        {
            inputFields.SetActive(false);
            savePage.SetActive(true);
            Invoke("openSaveForm", 0.3f);
        }
    }

    void openSaveForm()
    {
        inputFields.SetActive(false);
        saveForm.SetActive(true);
        StartCoroutine("fade");
        StartCoroutine("errorSplash");
    }

    IEnumerator fade()
    {
        while(opac < 1)
        {
            saveForm.GetComponent<Image>().color = new Color(1, 1, 1, opac);
            opac += 0.08f;
            yield return null;
        }        
        yield break;
    }

    IEnumerator errorSplash()
    {
        if(errorFlag) yield break;
        Cursor.visible = false;

        whiteScreen.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        freezeLoading.SetActive(true);

        yield return new WaitForSeconds(5f);
        errorSound.SetActive(true);
        yield return null;

        for(int i = 0; i < errorNum; i++)
        {
            errorImage[i].name = "error";
            int randomNum = (int)Random.Range(1, 19);
            errorImage[i].AddComponent<Image>().sprite = Resources.Load<Sprite>($"Errors/{randomNum}");
            errorImage[i].transform.SetParent(GameObject.Find("Canvas").transform);
            errorImage[i].GetComponent<RectTransform>().localPosition = new Vector3((int)Random.Range(-874, 921), (int)Random.Range(430,-414), 10);
            errorImage[i].GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            
            int width;
            int height;

            switch (randomNum)
            {
                case 1:
                    width = 324;
                    height = 154;
                    break;
                case 2:
                    width = 460;
                    height = 214;
                    break;
                case 3:
                    width = 645;
                    height = 301;
                    break;
                case 4:
                    width = 466;
                    height = 268;
                    break;
                case 5:
                    width = 457;
                    height = 214;
                    break;
                case 6:
                    width = 421;
                    height = 160;
                    break;
                case 7:
                    width = 652;
                    height = 172;
                    break;
                case 8:
                    width = 464;
                    height = 176;
                    break;
                case 9:
                    width = 353;
                    height = 171;
                    break;
                case 10:
                    width = 480;
                    height = 184;
                    break;
                case 11:
                    width = 794;
                    height = 115;
                    break;
                case 12:
                    width = 890;
                    height = 97;
                    break;
                case 13:
                    width = 841;
                    height = 93;
                    break;
                case 14:
                    width = 1205;
                    height = 105;
                    break;
                case 15:
                    width = 01;
                    height = 748;
                    break;
                case 16:
                    width = 843;
                    height = 66;
                    break;
                case 17:
                    width = 77;
                    height = 715;
                    break;
                case 18:
                    width = 1328;
                    height = 54;
                    break;
                default:
                    width = 700;
                    height = 50;
                    break;
            }

            errorImage[i].GetComponent<RectTransform>().sizeDelta = new Vector3(width, height, 0);
            Instantiate(errorImage[i]);
            yield return new WaitForSeconds(Random.Range(1, 1.4f));
        }

        // crashImage.SetActive(true);
        // yield return new WaitForSeconds(Random.Range(0, 0.3f));
        // crashImage.SetActive(false);
        // yield return new WaitForSeconds(Random.Range(0.1f, 1f));
        // crashImage.SetActive(true);
        // yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        // crashImage.SetActive(false);
        // yield return new WaitForSeconds(Random.Range(0.1f, 2f));
        // crashImage.SetActive(true);
        // yield return new WaitForSeconds(Random.Range(0f, 0.1f));
        // crashImage.SetActive(false);
        // yield return new WaitForSeconds(0.01f);
        // crashImage.SetActive(true);
        // yield return new WaitForSeconds(0.01f);
        // crashImage.SetActive(false);
        // yield return new WaitForSeconds(0.01f);
        // crashImage.SetActive(true);
        // yield return new WaitForSeconds(Random.Range(0f, 0.1f));
        // crashImage.SetActive(false);
        // yield return new WaitForSeconds(0.01f);
        // crashImage.SetActive(true);
        yield return new WaitForSeconds(Random.Range(0f, 0.1f));
        errorFlag = true;
        yield break;
    }
}
