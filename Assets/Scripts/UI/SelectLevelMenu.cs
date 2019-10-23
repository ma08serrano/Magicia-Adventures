using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelMenu : MonoBehaviour
{
    public GameObject selectLevelUI;

    private Animator _anim;

    public static bool isLevel1 = false;

    public static bool isLevel2 = false;

    public static bool isLevel3 = false;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = selectLevelUI.GetComponent<Animator>();
    }

    /******************************************
     * level01Button method
     ******************************************/
    public void Level01Button()
    {
        StartCoroutine(DelayExecution("level01"));
    }

    /******************************************
     * level02Button method
     ******************************************/
    public void Level02Button()
    {
        StartCoroutine(DelayExecution("level02"));
    }

    /******************************************
     * level03Button method
     ******************************************/
    public void Level03Button()
    {
        StartCoroutine(DelayExecution("level03"));
    }

    /******************************************
     * errorButton method
     ******************************************/
    public void ErrorButton()
    {
        _anim.SetBool("isError", true);
    }

    /******************************************
     * okButton method
     ******************************************/
    public void OkButton()
    {
        _anim.SetBool("isError", false);
    }

    /******************************************
     * backButton method
     ******************************************/
    public void BackButton()
    {
        StartCoroutine(DelayExecution("menu"));
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution(string method)
    {
        _anim.SetBool("isHide", true);
        yield return new WaitForSeconds(1.18f);

        if (method == "menu")
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (method == "level01")
        {
            SceneManager.LoadScene("Level01");

            isLevel1 = true;
            isLevel2 = false;
            isLevel3 = false;
        }
        else if (method == "level02")
        {
            SceneManager.LoadScene("Level02");

            isLevel1 = false;
            isLevel2 = true;
            isLevel3 = false;
        }
        else if (method == "level03")
        {
            SceneManager.LoadScene("Level03");

            isLevel1 = false;
            isLevel2 = false;
            isLevel3 = true;
        }
    }
}
