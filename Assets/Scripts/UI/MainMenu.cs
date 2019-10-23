using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;

    private Animator _anim;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = mainMenuUI.GetComponent<Animator>();
    }

    /******************************************
     * selectLevelsButton method
     ******************************************/
    public void SelectLevelsButton()
    {
        StartCoroutine(DelayExecution("selectLevels"));
    }

    /******************************************
     * highScoresButton method
     ******************************************/
    public void HighScoresButton()
    {
        StartCoroutine(DelayExecution("highScores"));
    }

    /******************************************
     * gameSettingsButton method
     ******************************************/
    public void GameSettingsButton()
    {
        StartCoroutine(DelayExecution("gameSettings"));
    }

    /******************************************
     * informationButton method
     ******************************************/
    public void InformationButton()
    {
        _anim.SetBool("isInformation", true);
    }

    /******************************************
     * closeButton method
     ******************************************/
    public void CloseButton()
    {
        _anim.SetBool("isInformation", false);
    }

    /******************************************
     * quitButton method
     ******************************************/
    public void QuitButton()
    {
        Application.Quit();
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution(string method)
    {
        _anim.SetBool("isHide", true);
        yield return new WaitForSeconds(1.5f);

        if (method == "selectLevels")
        {
            SceneManager.LoadScene("SelectLevels");
        }
        else if (method == "highScores")
        {
            SceneManager.LoadScene("HighScores");
        }
        else if (method == "gameSettings")
        {
            SceneManager.LoadScene("GameSettings");
        }
    }
}
