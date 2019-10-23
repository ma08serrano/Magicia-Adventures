using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // variable to determine if the damage function can be called
    private bool _canDamage = true;

    /******************************************
     * onTriggerEnter2D method
     ******************************************/
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            // if can attack
            // set the variable to false
            if (_canDamage == true)
            {
                hit.Damage(1);
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }

        }
    }

    /******************************************
     * coroutine to reset variable after 0.5f
     ******************************************/
    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
