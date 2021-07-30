using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    enum BullStates
    {
        Ready,
        Jumping,
        Loading
    };
    BullStates bullStates;

    [Header("Basic Movement")]
    [SerializeField] float speedMovement = 10f;
    [SerializeField] float speedRotation = 6f;

    [Header("Bull Stroke")]
    [SerializeField] float timeToLoad = 3f;
    [SerializeField] int collisionDamage = 5;
    [SerializeField] float forceStroke = 20f;
    [SerializeField] string[] objectivesTags;

    Rigidbody rig;
    PlayerStats player;
    TankAnimation tankAnimation;

    float vertical;
    float horizontal;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        tankAnimation = GetComponent<TankAnimation>();

        player = GetComponent<PlayerStats>();

        bullStates = BullStates.Ready;
    }

    void Update()
    {
        if (player.isLive)
        {
            BullInput();
        }
    }

    void FixedUpdate()
    {
        if (player.isLive)
        {
            PlayerInput();
        }
    }

    void PlayerInput()
    {
        // Forward Movement
        vertical = Input.GetAxis("Vertical");
        Vector3 newPosition = transform.position + (transform.forward * vertical * speedMovement * Time.deltaTime);
        rig.MovePosition(newPosition);

        // Rotation Movement
        horizontal = Input.GetAxis("Horizontal");
        Quaternion newRotation = transform.rotation * Quaternion.Euler(Vector3.up * horizontal * speedRotation);
        rig.MoveRotation(newRotation);

        tankAnimation.RotateWheels(vertical);
    }

    void BullInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bullStates == BullStates.Ready)
        {
            rig.AddForce(transform.forward * forceStroke, ForceMode.Acceleration);

            StartCoroutine(BullStroke());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < objectivesTags.Length; i++)
        {
            if (collision.transform.tag == objectivesTags[i])
            {
                if (bullStates == BullStates.Jumping)
                {
                    collision.transform.GetComponent<IDamageable>().TakeDamage(collisionDamage);
                }

                if (collision.transform.GetComponent<IObstacle>() != null)
                {
                    player.TakeDamage(collision.transform.GetComponent<IObstacle>().MakeDamage());
                }

                break;
            }
        }
    }

    IEnumerator BullStroke()
    {
        float time = 0;

        bullStates = BullStates.Jumping;
        rig.constraints = RigidbodyConstraints.FreezeRotationX;

        tankAnimation.BullStrokeLoader(false);

        while (time <= 1)
        {
            time += Time.deltaTime;
            yield return null;
        }

        bullStates = BullStates.Loading;
        rig.constraints = RigidbodyConstraints.None;
        time = 0;

        while (time <= timeToLoad)
        {
            time += Time.deltaTime;
            yield return null;
        }

        bullStates = BullStates.Ready;
        tankAnimation.BullStrokeLoader(true);
    }

}