using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        // assign handle to animator
        _anim = GetComponentInChildren<Animator>();
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    void Update()
    {
        
    }

    /******************************************
     * move method
     ******************************************/
    public void Move(float move)
    {
        // anim set float move, move
        _anim.SetFloat("Move", Mathf.Abs(move));
    }

    /******************************************
     * jump method
     ******************************************/
    public void Jump(bool jumping)
    {
        _anim.SetBool("Jumping", jumping);
    }

    /******************************************
     * attack method
     ******************************************/
    public void Attack()
    {
        _anim.SetTrigger("Attack");
    }

    /******************************************
     * death method
     ******************************************/
    public void Death()
    {
        _anim.SetTrigger("Death");
    }

    /******************************************
     * hit method
     ******************************************/
    public void Hit()
    {
        _anim.SetTrigger("Hit");
    }
}
