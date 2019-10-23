using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public Transform pointA, pointB;

    public Transform startPos;

    public float _speed;

    Vector3 nextPos;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        nextPos = startPos.position;
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    void Update()
    {
        if (transform.position == pointA.position)
        {
            nextPos = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            nextPos = pointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, _speed * Time.deltaTime);
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
