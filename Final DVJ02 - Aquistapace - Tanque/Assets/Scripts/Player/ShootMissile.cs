using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    public GameObject missilePref;
    public Transform turretDirection;
    public Transform reticleTrans;

    TankAnimation tankAnimation;

    void Start()
    {
        tankAnimation = GetComponent<TankAnimation>();
    }

    public void FireTheTurret()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float newSpeed = Vector3.Distance(turretDirection.position, reticleTrans.position) * 2;

            GameObject missile = Instantiate(missilePref, turretDirection.position, turretDirection.rotation);
            missile.GetComponent<Rigidbody>().velocity = turretDirection.forward * newSpeed;

            tankAnimation.FireAnimation();

            Destroy(missile, 2f);
        }
    }
}
