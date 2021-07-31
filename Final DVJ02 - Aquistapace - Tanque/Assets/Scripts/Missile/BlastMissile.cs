using UnityEngine;

public class BlastMissile : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float blastRadius;
    [SerializeField] int damage = 10;
    [SerializeField] string[] objectivesTags;
    [SerializeField] float blastTime = 0.5f;

    SphereCollider circle;

    void Awake()
    {
        circle = GetComponent<SphereCollider>();

        circle.radius = blastRadius;

        Destroy(this.gameObject, blastTime);
    }

    void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < objectivesTags.Length; i++)
        {
            if (other.transform.tag == objectivesTags[i])
            {
                other.transform.GetComponent<IDamageable>().TakeDamage(damage);

                Debug.LogWarning(other.transform.name);

                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, blastRadius);
    }
}
