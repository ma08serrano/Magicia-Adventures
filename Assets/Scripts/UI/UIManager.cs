using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    /******************************************
     * instance method
    ******************************************/
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is Null!");
            }

            return _instance;
        }
    }

    public Text scoreCountText;
    public Text playerCoinCountText;
    public Image selectionImg;
    public Text coinCountText;
    public Image[] healthBars;

    /******************************************
     * open shop awake
     ******************************************/
    private void Awake()
    {
        _instance = this;
    }

    /******************************************
     * open shop method
     ******************************************/
    public void OpenShop(int coinCount)
    {
        playerCoinCountText.text = "" + coinCount + "G";
    }

    /******************************************
     * update shop selection method
     ******************************************/
    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    /******************************************
     * update coin amount method
     ******************************************/
    public void UpdateCoinCount(int count)
    {
        coinCountText.text = "" + count;
    }

    /******************************************
     * update score amount method
     ******************************************/
    public void UpdateScoreCount(int count)
    {
        scoreCountText.text = "" + count;
    }

    /******************************************
     * update lives method
     ******************************************/
    public void UpdateLives(int livesRemaining)
    {
        Debug.Log("Lives Index: " + livesRemaining);

        // if the player fell on the spike
        if (livesRemaining < 1)
        {
            healthBars[0].enabled = false;
            healthBars[1].enabled = false;
            healthBars[2].enabled = false;
            healthBars[3].enabled = false;
        }
        else 
        {
            // loop through lives
            // i == livesremaining
            // hide that one
            for (int i = 0; i <= livesRemaining; i++)
            {
                // do nothing till we hit the max
                if (i == livesRemaining)
                {
                    healthBars[i].enabled = false;
                }
            }
        }
    }
}
