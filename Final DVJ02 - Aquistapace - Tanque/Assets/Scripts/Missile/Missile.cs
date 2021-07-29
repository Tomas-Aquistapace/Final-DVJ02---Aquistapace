using UnityEngine;

public class Missile : MonoBehaviour
{
    [Header("Explosion")]
    //public string[] objectivesTags;
    //public int damage = 10;
    [SerializeField] GameObject blastObj;

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
        Destroy(explosion, 3f);

        GameObject blast = Instantiate(blastObj, transform.position, transform.rotation);

        //for (int i = 0; i < objectivesTags.Length; i++)
        //{
        //
        //    if (collision.transform.tag == objectivesTags[i])
        //    {
        //
        //        Debug.LogError("Que onda");
        //        collision.transform.GetComponent<IDamageable>().TakeDamage(damage);
        //
        //        break;
        //    }
        //}

        Destroy(this.gameObject);
    }
}
