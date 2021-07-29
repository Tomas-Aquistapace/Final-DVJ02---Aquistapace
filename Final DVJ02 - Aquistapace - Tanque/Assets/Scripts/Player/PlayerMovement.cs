using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movement")]
    [SerializeField] float speedMovement = 10f;
    [SerializeField] float speedRotation = 6f;

    [Header("Bull Stroke")]
    [SerializeField] bool hableToStroke = true;
    [SerializeField] float timeToLoad = 3f;
    [SerializeField] int collisionDamage = 5;
    [SerializeField] float forceStroke = 20f;
    [SerializeField] float minSpeedDamage = 10f; // desuso
    [SerializeField] string[] objectivesTags;

    Rigidbody rig;
    PlayerStats player;
    TankAnimation tankAnimation;
    float speedModifier = 10f;

    float vertical;
    float horizontal;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        tankAnimation = GetComponent<TankAnimation>();

        player = GetComponent<PlayerStats>();
    }

    void Update()
    {
        BullInput();
    }

    void FixedUpdate()
    {
        PlayerInput();
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
        if (Input.GetKeyDown(KeyCode.Space) && hableToStroke)
        {

            rig.AddForce(transform.forward * forceStroke, ForceMode.Acceleration);


        }
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < objectivesTags.Length; i++)
        {
            if (collision.transform.tag == objectivesTags[i])
            {
                float actualSpeed = rig.velocity.magnitude * speedModifier;
                Debug.Log(actualSpeed);

                if (actualSpeed >= minSpeedDamage)
                {
                    collision.transform.GetComponent<IDamageable>().TakeDamage(collisionDamage);
                }
                
                if(collision.transform.GetComponent <IObstacle>() != null)
                {
                    player.TakeDamage(collision.transform.GetComponent<IObstacle>().MakeDamage());
                }

                break;
            }
        }

    }
}
