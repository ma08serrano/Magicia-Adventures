using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    /******************************************
     * health getter and setter
     ******************************************/
    int Health { get; set; }

    /******************************************
     * damage method
     ******************************************/
    void Damage(int damageNum);
}
