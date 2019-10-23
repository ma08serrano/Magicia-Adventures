using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;

    private Animator _anim;

    private Player _player;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = completeLevelUI.GetComponent<Animator>();
    }

    /******************************************
     * onTriggerEnter2D method
     ******************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();

            if (_player != null)
            {
                Debug.Log("Level Complete!");

                completeLevelUI.SetActive(true);
                _anim.SetBool("isOpen", true);
            }
        }
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
     * level04Button method
     ******************************************/
    public void Level04Button()
    {
        StartCoroutine(DelayExecution("level04"));
    }

    /******************************************
     * exitGameButton method
     ******************************************/
    public void ExitGameButton()
    {
        StartCoroutine(DelayExecution("exit"));
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution(string method)
    {
        _anim.SetBool("isHide", true);
        yield return new WaitForSeconds(1.2f);

        if (method == "level01")
        {
            SceneManager.LoadScene("Level01");

            SelectLevelMenu.isLevel1 = true;
            SelectLevelMenu.isLevel2 = false;
            SelectLevelMenu.isLevel3 = false;
        }
        else if (method == "level02")
        {
            SceneManager.LoadScene("Level02");

            SelectLevelMenu.isLevel1 = false;
            SelectLevelMenu.isLevel2 = true;
            SelectLevelMenu.isLevel3 = false;
        }
        else if (method == "level03")
        {
            SceneManager.LoadScene("Level03");

            SelectLevelMenu.isLevel1 = false;
            SelectLevelMenu.isLevel2 = false;
            SelectLevelMenu.isLevel3 = true;
        }
        else if (method == "level04")
        {

        }
        else if (method == "exit")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
