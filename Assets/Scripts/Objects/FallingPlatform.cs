using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D _rigid;

    public float fallDelay;

    /******************************************
     * Start is called before the first frame update
     ******************************************/
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    /******************************************
     * Update is called once per frame
     ******************************************/
    void Update()
    {
        
    }

    /******************************************
     * called when the player hits the floor
     ******************************************/
    void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log("OnCollisionEnter2D");
        if (other.collider.CompareTag("Player"))
            StartCoroutine(Fall());
    }

    /******************************************
     * fall method
     ******************************************/
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        _rigid.isKinematic = false;
        
        yield return 0;
    }
}
