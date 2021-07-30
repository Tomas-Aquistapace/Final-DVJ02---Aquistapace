using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public delegate void CheckLife(int maxLife, int life);
    public static CheckLife CalculateLife;
    public delegate void WinLose(bool state);
    public static WinLose FinishGame;

    public int maxLife = 100;
    public int life = 100;
    public bool isLive = true;

    void Start()
    {
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

        FinishGame(isLive);
    }
}