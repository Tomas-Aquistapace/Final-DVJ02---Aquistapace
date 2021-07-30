using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable, IObstacle
{
    [SerializeField] int life = 1;
    [SerializeField] int collisionDamage = 0;

    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        if (life <= 0)
        {
            Eliminated();
        }
    }

    public void Eliminated()
    {
        Destroy(this.gameObject);
    }

    public int MakeDamage()
    {
        return collisionDamage;
    }
}
