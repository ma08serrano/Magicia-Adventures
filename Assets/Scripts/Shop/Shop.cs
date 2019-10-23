using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public GameObject shopPanel;

    private Animator _anim;

    private Player _player;

    public int currentSelectedItem;

    public int currentItemCost;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = shopPanel.GetComponent<Animator>();
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
                UIManager.Instance.OpenShop(_player.coinAmount);
            }

            shopPanel.SetActive(true);
            _anim.SetBool("isOpen", true);
        }
    }

    /******************************************
     * onTriggerExit2D method
     ******************************************/
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(DelayExecution());
        }
    }

    /******************************************
     * selectItem method
     ******************************************/
    public void SelectItem(int item)
    {
        // 0 = health
        // 1 = speed
        // 2 = key to castle
        Debug.Log("SelectItem() : " + item);

        // switch between item
        // case 0
        switch(item)
        {
            case 0:
                UIManager.Instance.UpdateShopSelection(78);
                currentSelectedItem = 0;
                currentItemCost = 5;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-27);
                currentSelectedItem = 1;
                currentItemCost = 10;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-131);
                currentSelectedItem  = 2;
                currentItemCost = 15;
                break;
        }
    }

    /******************************************
     * buy item method
     * check if player coins is greater than or equal to item cost
     * if it is, then award item (subtract cost from players gems)
     * else cancel sale
     ******************************************/
    public void BuyItem()
    {
        if (_player.coinAmount >= currentItemCost)
        {
            // award item
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player.coinAmount -= currentItemCost;
            Debug.Log("Purchased " + currentSelectedItem);
            Debug.Log("Remaining Coins: " + _player.coinAmount);
            StartCoroutine(DelayExecution());
        } 
        else
        {
            Debug.Log("You do not have enough coins. Closing Shop");
            StartCoroutine(DelayExecution());
        }
    }

    /******************************************
     * delayExecution iEnumerator
     ******************************************/
    IEnumerator DelayExecution()
    {
        _anim.SetBool("isHide", true);
        yield return new WaitForSeconds(0.4f);
        shopPanel.SetActive(false);
    }
}
