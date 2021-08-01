using UnityEngine;

public class Obstacle : MonoBehaviour, IDamageable, IObstacle
{
    [SerializeField] int life = 1;
    [SerializeField] int collisionDamage = 0;
    [SerializeField] int pointsValue = 0;

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


        Destroy(this.gameObject);
    }

    public int MakeDamage()
    {
        return collisionDamage;
    }
}
