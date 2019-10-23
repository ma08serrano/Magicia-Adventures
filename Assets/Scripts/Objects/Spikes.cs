using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
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
                player.Damage(4);
            }
        }
    }
}
