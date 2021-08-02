using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public delegate void WinLose(bool state);
    //public static WinLose FinishGame;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject player;

    [SerializeField] float MaxMinutes = 3f;
    [SerializeField] float MaxSeconds = 0f;

    [HideInInspector] public float minutesClock;
    [HideInInspector] public float secondsClock;

    const float MINUTES = 60f;
    private bool activateTimer;

    void Start()
    {
        minutesClock = MaxMinutes;
        secondsClock = MaxSeconds;

        activateTimer = true;
    }

    private void LateUpdate()
    {
        if (activateTimer == true)
        {
            secondsClock -= Time.deltaTime;

            if (secondsClock < 0)
            {
                minutesClock--;

                if (minutesClock <= 0 && secondsClock <= 0)
                {
                    PlayerStats.FinishGame(player.GetComponent<PlayerStats>().isLive);
                    activateTimer = false;
                }
                else
                {
                    secondsClock = MINUTES;
                }
            }
        }
    }

}
