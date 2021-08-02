using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageable
{
    public enum State
    { 
        Playing,
        Win,
        Lose
    };
    [HideInInspector] public State pState;

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
        FinishGame += ChangeState;
    }

    void OnDisable()
    {
        CalculatePoints -= EarnPoints;
        FinishGame -= ChangeState;
    }    

    void Start()
    {
        tankAnimation = GetComponent<TankAnimation>();

        life = maxLife;

        isLive = true;
        pState = State.Playing;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;

        PopUpManager.CallPopUp(this.transform, damage, true);

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

    // ----------------------------
    
    public void EarnPoints(int newPoints)
    {
        points += newPoints;
    }

    public void ChangeState(bool state)
    {
        if(state)
        {
            pState = State.Win;
        }
        else
        {
            pState = State.Lose;
        }
    }
}