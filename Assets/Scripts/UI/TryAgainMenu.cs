using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainMenu : MonoBehaviour
{
    public GameObject tryAgainUI;

    private Animator _anim;

    private bool isRestart  = false;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = tryAgainUI.GetComponent<Animator>();
    }

    /******************************************
     * tryAgainButton method
     ******************************************/
    public void TryAgainButton()
    {
        isRestart = true;

        StartCoroutine(DelayExecution());
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution()
    {
        _anim.SetBool("isHide", true);
        yield return new WaitForSeconds(2.1f);

        if (isRestart == true)
        {
            if (SelectLevelMenu.isLevel1 == true)
            {
                SceneManager.LoadScene("Level01");
            } else if (SelectLevelMenu.isLevel2 == true) {
                SceneManager.LoadScene("Level02");
            } else if (SelectLevelMenu.isLevel3 == true) {
                SceneManager.LoadScene("Level03");
            }
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    /******************************************
     * exitButton method
     ******************************************/
    public void ExitButton()
    {
        isRestart = false;

        StartCoroutine(DelayExecution());
    }
}
