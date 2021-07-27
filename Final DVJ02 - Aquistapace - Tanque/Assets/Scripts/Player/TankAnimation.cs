using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    [Header("Wheel Animation")]
    public GameObject[] wheels;
    [SerializeField] float speedRotation = 10f;

    [Header("Fire Animation")]
    public Animator animator;
    public GameObject shockWave;
    public Transform canyonTip;

    [Header("Loader Particles")]
    public GameObject[] radioLoader;

    void Start()
    {
        radioLoader[0].SetActive(true);
        radioLoader[1].SetActive(false);
    }

    public void RotateWheels(float rotation)
    {
        if(rotation != 0)
        {
            foreach (GameObject wheel in wheels)
            {
                wheel.transform.Rotate(Vector3.right * rotation * speedRotation * Time.deltaTime);
            }
        }
    }

    public void FireAnimation()
    {
        animator.SetTrigger("Fire");

        GameObject particle = Instantiate(shockWave, canyonTip.position, canyonTip.rotation);
        Destroy(particle, 1f);
    }

    public void IsLoaded(bool state)
    {
        if (state)
        {
            radioLoader[0].SetActive(true);
            radioLoader[1].SetActive(false);
        }
        else
        {
            radioLoader[0].SetActive(false);
            radioLoader[1].SetActive(true);
        }
    }
}
