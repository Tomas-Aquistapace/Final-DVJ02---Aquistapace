using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarCannon : MonoBehaviour
{
    [Header("Particles and Missile")]
    [SerializeField] GameObject missile;
    [SerializeField] Vector3 missilePos;
    [SerializeField] GameObject shockWave;
    [SerializeField] Transform canyonTip;

    [Header("Crosshair Stats")]
    [SerializeField] GameObject crosshair;
    [SerializeField] float speedCrosshair = 2f;
    
    [Header("Cannon Stats")]
    [SerializeField] Transform cannon;
    [SerializeField] float radiusScope = 16f;
    [SerializeField] float timeToShoot = 3f;
    [SerializeField] float reloadTime = 5f;

    Transform player;
    float time;
    bool reload = false;

    private void Start()
    {
        player = GameManager.instance.player.transform;

        time = 0f;

        crosshair.SetActive(false);
    }

    private void LateUpdate()
    {
        Vector3 distance = transform.position - player.position;

        if (distance.magnitude <= radiusScope)
        {
            crosshair.SetActive(true);

            if(player.GetComponent<PlayerStats>().pState == PlayerStats.State.Playing && player.GetComponent<PlayerStats>().isLive)
            {
                ShootTheMortar();
            }
        }
        else
        {
            crosshair.SetActive(false);
        }

    }

    void ShootTheMortar()
    {
        time += Time.deltaTime;

        if (reload)
        {
            if(time > reloadTime)
            {
                reload = false;
                time = 0f;
            }
        }
        else
        {
            if (time > timeToShoot && reload == false)
            {
                Vector3 spawnPos = crosshair.transform.position + missilePos;
                GameObject go = Instantiate(missile, spawnPos, missile.transform.rotation);

                GameObject particle = Instantiate(shockWave, canyonTip.position, canyonTip.rotation);
                Destroy(particle, 1f);

                reload = true;

                time = 0f;
            }
            else
            {
                cannon.LookAt(crosshair.transform, Vector3.up);
                crosshair.transform.position = Vector3.Lerp(crosshair.transform.position, player.position, speedCrosshair * Time.deltaTime);
            }
        }

        crosshair.transform.Rotate(new Vector3(0, 0.15f, 0));
    }

    // ------------------------

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radiusScope);
    }
}
