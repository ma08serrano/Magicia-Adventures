using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    /******************************************
     * onTriggerEnter2D method
     ******************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check for the player
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null) {
                player.Damage(1);
            }
        }
    }
}
