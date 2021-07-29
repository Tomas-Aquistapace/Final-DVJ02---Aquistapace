using System.Collections;
using UnityEngine;

public class ShootMissile : MonoBehaviour
{
    public GameObject missilePref;
    public Transform turretDirection;
    public Transform reticleTrans;
    public float rechargeTime = 2f;

    TankAnimation tankAnimation;
    bool isLoaded;

    void Start()
    {
        tankAnimation = GetComponent<TankAnimation>();
        isLoaded = true;
    }

    void Update()
    {
        FireTheTurret();
    }

    void FireTheTurret()
    {
        if (Input.GetMouseButtonDown(1) && isLoaded)
        {
            StartCoroutine(Recharge());

            float newSpeed = Vector3.Distance(turretDirection.position, reticleTrans.position) * 2.25f;

            GameObject missile = Instantiate(missilePref, turretDirection.position, turretDirection.rotation);
            missile.GetComponent<Rigidbody>().velocity = turretDirection.forward * newSpeed;

            tankAnimation.FireAnimation();

            Destroy(missile, 2f);
        }
    }

    IEnumerator Recharge()
    {
        float time = 0f;

        isLoaded = false;
        tankAnimation.MissileLoader(isLoaded);

        while (time <= rechargeTime)
        {
            time += Time.deltaTime;

            yield return null;
        }

        isLoaded = true;
        tankAnimation.MissileLoader(isLoaded);
    }
}
