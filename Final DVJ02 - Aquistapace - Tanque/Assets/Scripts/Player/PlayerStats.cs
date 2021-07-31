using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public delegate void CheckLife(int maxLife, int life);
    public static CheckLife CalculateLife;
    public delegate void CheckPoints(int newPoints);
    public static CheckPoints CalculatePoints;
    public delegate void WinLose(bool state);
    public static WinLose FinishGame;

    public int maxLife = 100;
    public int life = 100;
    public int points = 0;

    public bool isLive = true;

    TankAnimation tankAnimation;

    void OnEnable()
    {
        CalculatePoints += EarnPoints;
    }

    void OnDisable()
    {
        CalculatePoints -= EarnPoints;
    }

    public void EarnPoints(int newPoints)
    {
        Debug.Log("-");

        points += newPoints;
    }

    void Start()
    {
        tankAnimation = GetComponent<TankAnimation>();

        life = maxLife;

        isLive = true;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        CalculateLife(maxLife, life);

        if(life <= 0)
        {
            Eliminated();
        }
    }

    public void Eliminated()
    {
        isLive = false;

        tankAnimation.ActivateDeadAnim();

        FinishGame(isLive);
    }
}