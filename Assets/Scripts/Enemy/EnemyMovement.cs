using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy, IDamageable
{
    protected static int scores;

    private float restartDelay = 1.9f;

    public int Health { get; set; }

    /******************************************
     * use for initialization
     ******************************************/
    public override void Init()
    {
        base.Init();

        // assign health property to our enemy health
        Health = base.health;

        // reset the scores when starting the game
        scores = 0;
    }

    /******************************************
     * movement method
     ******************************************/
    public override void Movement()
    {
        base.Movement();
    }

    /******************************************
     * damage method
     ******************************************/
    public void Damage(int damageNum)
    {
        if (isDead == true)
            return;

        Debug.Log("Enemy::Damage()");

        // subtract 1 from health
        Health -= damageNum;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("Combat", true);

        // if health is less than 1
        // destroy the object
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            Invoke("DestroyObject", restartDelay);

            // spawn a coin
            // change value of coin to whatever my coin amount is
            GameObject coinAmount = (GameObject)Instantiate(coinPrefab, transform.position, Quaternion.identity) as GameObject;
            coinAmount.GetComponent<Coin>().coins = base.coins;

            scores += 10;
            UIManager.Instance.UpdateScoreCount(scores);
        }
    }

    /******************************************
     * destroyObject method
     ******************************************/
    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    /******************************************
     * onTriggerEnter to collect
     ******************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check for the player
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null && isDead == false) {
                player.Damage(1);
            }
        }
    }
}
