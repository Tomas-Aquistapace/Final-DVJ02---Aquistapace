using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speedMovement = 10f;
    [SerializeField] float speedRotation = 6f;

    Rigidbody rig;
    TankAnimation tankAnimation;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        tankAnimation = GetComponent<TankAnimation>();
    }
    
    void FixedUpdate()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        // Forward Movement
        float vertical = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + (transform.forward * vertical * speedMovement * Time.deltaTime);
        rig.MovePosition(newPosition);

        tankAnimation.RotateWheels(vertical);

        // Rotation Movement
        float horizontal = Input.GetAxis("Horizontal");
        Quaternion newRotation = transform.rotation * Quaternion.Euler(Vector3.up * horizontal * speedRotation);
        rig.MoveRotation(newRotation);

    }
}
