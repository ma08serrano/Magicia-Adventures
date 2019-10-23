using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private float restartDelay = 1f;

    /******************************************
     * instance method
     ******************************************/
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is Null!");
            }

            return _instance;
        }
    }

    public bool HasKeyToCastle { get; set; }

    /******************************************
     * awake method
     ******************************************/
    private void Awake()
    {
        _instance = this;
    }

    /******************************************
     * endGame method
     ******************************************/
    public void EndGame()
    {
        Debug.Log("Game Over!");

        // Delay restarting the game
        Invoke("Restart", restartDelay);
    }

    /******************************************
     * restart method
     ******************************************/
    private void Restart()
    {
        // Restart the scene after death
        SceneManager.LoadScene("TryAgain");
    }
}
