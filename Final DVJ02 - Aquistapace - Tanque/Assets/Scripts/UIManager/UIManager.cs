using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject player;
    [SerializeField] Color fullLife = Color.green;
    [SerializeField] Color treeQuarters = Color.yellow;
    [SerializeField] Color twoQuarters = Color.yellow;
    [SerializeField] Color oneQuarters = Color.red;

    [Header("Posters")]
    public string endScene;

    [Header("UI Texts")]
    public TextMeshProUGUI lifesTxt;
    public Image lifesPng;
    public TextMeshProUGUI pointsTxt;
    public TextMeshProUGUI timeMinutesText;
    public TextMeshProUGUI timeSecondsText;

    private float minutesClock;
    private float secondsClock;

    private float MaxMinutes = 3f;
    private float MaxSeconds = 0f;

    const float MINUTES = 60f;

    int points = 0;

    private void Awake()
    {
        points = 0;

        minutesClock = MaxMinutes;
        secondsClock = MaxSeconds;

        lifesPng.color = fullLife;
    }

    private void OnEnable()
    {
        //PlayerStats.WinGame += ShowFinalScene;
        PlayerStats.CalculateLife += TotalLife;
        PlayerStats.FinishGame += ShowFinalScene;
        PlayerStats.CalculatePoints += TotalPoints;
    }

    private void OnDisable()
    {
        //PlayerStats.WinGame -= ShowFinalScene;
        PlayerStats.CalculateLife -= TotalLife;
        PlayerStats.FinishGame -= ShowFinalScene;
        PlayerStats.CalculatePoints -= TotalPoints;
    }

    public void ShowFinalScene(bool result)
    {
        //GameManager.instance.finalState = result;

        //SceneManager.LoadScene(endScene);
    }

    // ------------------

    public void TotalLife(int maxLife, int life)
    {
        int treeQuarLife = maxLife - maxLife / 4;
        int twoQuarLife = maxLife / 2;
        int oneQuarLife = maxLife / 4;

        if (life <= maxLife && life > treeQuarLife)
        {
            lifesPng.color = fullLife;
        }
        else if (life <= treeQuarLife && life > twoQuarLife)
        {
            lifesPng.color = treeQuarters;
        }
        else if (life <= twoQuarLife && life > oneQuarLife)
        {
            lifesPng.color = twoQuarters;
        }
        else if (life <= oneQuarLife && life > 0)
        {
            lifesPng.color = oneQuarters;
        }
    }

    public void TotalPoints(int amount)
    {
        points += amount;

        pointsTxt.text = points.ToString();
    }

    private void LateUpdate()
    {
        secondsClock -= Time.deltaTime;

        timeSecondsText.text = Mathf.Floor(secondsClock).ToString();

        if (secondsClock < 0)
        {
            secondsClock = MINUTES;
            minutesClock--;
            timeMinutesText.text = minutesClock.ToString();
        }
    }
}
