using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    public GameObject missilePref;
    public Transform turretDirection;
    public Transform reticleTrans;


    public void FireTheTurret()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float newSpeed = Vector3.Distance(turretDirection.position, reticleTrans.position) * 2;

            GameObject missile = Instantiate(missilePref, turretDirection.position, turretDirection.rotation);
            missile.GetComponent<Rigidbody>().velocity = turretDirection.forward * newSpeed;

            Destroy(missile, 2f);
        }
    }
}
