using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coins = 1;

    /******************************************
     * onTriggerEnter to collect
     ******************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check for the player
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            // add the value of the coin to the player
            if (player != null) {
                // Debug.Log("Coin Amount: " + coins);
                player.AddCoins(coins);
                Destroy(this.gameObject);
            }
        }
    }
}
