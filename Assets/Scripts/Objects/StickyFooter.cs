using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFooter : MonoBehaviour
{
    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    void Update()
    {
        
    }

    /******************************************
     * player stay on the moving floor
     ******************************************/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
            other.collider.transform.SetParent(transform);
    }  

    /******************************************
     * let the player move freely after hitting the moving object
     ******************************************/
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
            other.collider.transform.SetParent(null);
    }  
}
