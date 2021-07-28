using UnityEngine;

public class Missile : MonoBehaviour
{
    [Header("Stats")]
    public string objectiveTag;
    public int damage = 10;

    [Header("Visual Effects")]
    public GameObject explosionParticle;

    Rigidbody rig;
    Vector3 direction;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        direction = transform.localPosition;
    }

    void Update()
    {
        //float angle = Mathf.Atan2(rig.velocity.y, rig.velocity.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(explosion, 5f);

        Destroy(this.gameObject);


        if (collision.transform.tag == objectiveTag)
        {
            collision.transform.GetComponent<IDamageable>().TakeDamage(damage);
        }
    }
}
