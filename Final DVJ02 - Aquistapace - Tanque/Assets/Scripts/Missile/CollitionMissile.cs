﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollitionMissile : MonoBehaviour
{

    [SerializeField] GameObject explosionParticle;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(explosion, 5f);

        Destroy(this.gameObject);
    }

}