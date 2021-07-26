﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTurret : MonoBehaviour
{
    [Header("Reticle")]
    [SerializeField] Transform reticleTrans;
    [SerializeField] Vector3 reticleAltitude;
    [SerializeField] LayerMask particularLayer;

    [Header("Rotation Turret")]
    [SerializeField] float speedRotation = 10f;
    [SerializeField] Transform turret;

    private new Camera camera;
    private Vector3 destinyRot;
    private Vector3 turretLookDir;

    ShootMissile shootMissile;

    void Start()
    {
        camera = GameObject.FindObjectOfType<Camera>();
        shootMissile = GetComponent<ShootMissile>();

        turretLookDir = reticleTrans.position - turret.position;
        turretLookDir.y = 0f;
    }

    void Update()
    {
        UpdateReticle();
        RotateTurret();
    }

    void UpdateReticle()
    {
        Ray mouseRay = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, 100, particularLayer))
        {
            reticleTrans.position = hit.point + reticleAltitude;
        }
    }

    void RotateTurret()
    {
        if (Input.GetMouseButton(0))
        {
            turretLookDir = reticleTrans.position - turret.position;
            turretLookDir.y = 0f;

            shootMissile.FireTheTurret();
        }
        
        destinyRot = Vector3.Lerp(destinyRot, turretLookDir, Time.deltaTime * speedRotation);
        turret.rotation = Quaternion.LookRotation(destinyRot);
    }
}