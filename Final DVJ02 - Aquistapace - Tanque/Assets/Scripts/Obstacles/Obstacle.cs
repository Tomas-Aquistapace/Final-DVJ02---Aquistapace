using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable, IObstacle
{
    [SerializeField] int life = 1;
    [SerializeField] int collisionDamage = 0;
    [SerializeField] int pointsValue = 0;
    [SerializeField] bool destroyOnColl = false;

    public GameObject destroyParticle;

    private void OnEnable()
    {
        PlayerStats.CalculatePoints += GivePoints;
    }

    private void OnDisable()
    {
        PlayerStats.CalculatePoints -= GivePoints;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        PopUpManager.CallPopUp(this.transform, damage, false);

        if (life <= 0)
        {
            PlayerStats.CalculatePoints(pointsValue);

            Eliminated();
        }
    }

    public void GivePoints(int newPoints)
    {
        //Debug.Log(newPoints);
    }

    public void Eliminated()
    {
        GameObject go = Instantiate(destroyParticle, transform.position, transform.rotation);
        Destroy(go, 3f);
        Destroy(this.gameObject);
    }

    public int MakeDamage()
    {
        return collisionDamage;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (destroyOnColl)
            {
                Eliminated();
            }
        }
    }
}
