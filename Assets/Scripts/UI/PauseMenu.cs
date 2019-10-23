using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    private Animator _anim;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = pauseUI.GetComponent<Animator>();
    }

    /******************************************
     * resumeButton method
     ******************************************/
    public void ResumeButton()
    {
        StartCoroutine(DelayExecution("hide"));
    }

    /******************************************
     * pauseButton method
     ******************************************/
    public void PauseButton()
    {
        pauseUI.SetActive(true);
        _anim.SetBool("isOpen", true);
        _anim.SetBool("isHide", false);

        Time.timeScale = 0f;
    }

    /******************************************
     * exitButton method
     ******************************************/
    public void ExitButton()
    {
        StartCoroutine(DelayExecution("quit"));
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution(string method)
    {
        if (method == "quit")
        {
            _anim.SetBool("isQuit", true);

            Time.timeScale = 1f;
            yield return new WaitForSeconds(1.1f);
            SceneManager.LoadScene("MainMenu");
        }
        else if(method == "hide")
        {
            _anim.SetBool("isHide", true);

            Time.timeScale = 1f;
            yield return new WaitForSeconds(0.7f);
            pauseUI.SetActive(false);
        }
    }
}
