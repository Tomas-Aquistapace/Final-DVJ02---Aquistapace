using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    [Header("Wheel Animation")]
    public GameObject[] wheels;
    [SerializeField] float speedRotation = 10f;

    public Animator animator;

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
    }
}
