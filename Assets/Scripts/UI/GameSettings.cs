using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    public GameObject gameSettingsUI;

    private Animator _anim;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = gameSettingsUI.GetComponent<Animator>();
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
    }
}
