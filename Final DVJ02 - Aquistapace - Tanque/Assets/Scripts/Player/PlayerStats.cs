using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    int life = 100;

    void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if(life <= 0)
        {
            Eliminated();
        }
    }

    public void Eliminated()
    {

    }
}
