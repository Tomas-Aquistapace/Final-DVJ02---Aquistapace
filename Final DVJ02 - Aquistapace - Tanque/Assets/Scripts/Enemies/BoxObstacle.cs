using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxObstacle : MonoBehaviour, IDamageable
{
    public int life = 1;

    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Eliminated();
        }
    }

    public void Eliminated()
    {
        Destroy(this.gameObject);
    }
}
