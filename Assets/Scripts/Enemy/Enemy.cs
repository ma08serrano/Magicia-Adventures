using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected int health;

    [SerializeField]
    protected float speed;

    [SerializeField]
    protected int coins;

    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;

    protected Animator anim;

    protected SpriteRenderer sprite;

    protected Player player;

    protected bool isHit = false;

    protected bool isDead = false;

    public GameObject coinPrefab;

    /******************************************
     * init virtual method
     ******************************************/
    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    private void Start()
    {
        Init();
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    public virtual void Update() 
    {
        // if idle animation
        // do nothing (return)
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("Combat") == false)
        {
            return;
        }

        if (isDead == false)
            Movement();
    }

    /******************************************
     * movement virtual method
     ******************************************/
    public virtual void Movement()
    {
        if (currentTarget == pointA.position) 
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        // if current pos == pointA
        // move to pointB
        // else if current pos = pointB
        // move to pointA
        if (transform.position == pointA.position) 
        {
            // move to right
            // Debug.Log("PointA");
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            // move to left
            // Debug.Log("PointB");
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if (isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        // check for distance between player and enemy
        // if greater than 10 units
        // isHit = false
        // inCombat = false
        float distance = Vector3.Distance(transform.position, player.transform.position);
        // Debug.Log("Distance: " + distance + " for: " + transform.name);

        if (distance > 10.0f)
        {
            isHit = false;
            anim.SetBool("Combat", false);
        }

        Vector3 direction = player.transform.position - transform.position;

        // Debug.Log("Side: " + direction.x);

        if (direction.x > 0 && anim.GetBool("Combat") == true)
        {
            // face right
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("Combat") == true)
        {
            // face left
            sprite.flipX = true;
        }
    }
}
