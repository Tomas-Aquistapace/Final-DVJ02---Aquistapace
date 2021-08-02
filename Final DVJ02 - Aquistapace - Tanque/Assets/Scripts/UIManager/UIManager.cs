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

    [Header("End Game")]
    public GameObject endPoster;
    public GameObject victoryText;
    public GameObject failedText;
    public TextMeshProUGUI finalPointsText;
    public TextMeshProUGUI finalDistanceText;

    [Header("UI Player")]
    public GameObject HUD;
    public TextMeshProUGUI lifesText;
    public Image lifesPng;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI timeMinutesText;
    public TextMeshProUGUI timeSecondsText;

    int points = 0;

    private void Awake()
    {
        points = 0;

        lifesPng.color = fullLife;
        lifesText.color = fullLife;
        lifesText.text = player.GetComponent<PlayerStats>().maxLife.ToString();

        endPoster.SetActive(false);
        HUD.SetActive(true);
    }

    private void OnEnable()
    {
        PlayerStats.CalculateLife += TotalLife;
        PlayerStats.FinishGame += ShowFinalPoster;
        PlayerStats.CalculatePoints += TotalPoints;
        PlayerStats.FinishGame += ShowFinalPoster;
    }

    private void OnDisable()
    {
        PlayerStats.CalculateLife -= TotalLife;
        PlayerStats.FinishGame -= ShowFinalPoster;
        PlayerStats.CalculatePoints -= TotalPoints;
        PlayerStats.FinishGame -= ShowFinalPoster;
    }

    void Update()
    {
        distanceText.text = player.GetComponent<PlayerMovement>().distanceTraveled.ToString("0.0");
    }

    public void ShowFinalPoster(bool result)
    {
        endPoster.SetActive(true);
        HUD.SetActive(false);

        finalPointsText.text = points.ToString();
        finalDistanceText.text = player.GetComponent<PlayerMovement>().distanceTraveled.ToString("0.0");

        if (result)
        {
            victoryText.SetActive(true);
            failedText.SetActive(false);
        }
        else
        {
            victoryText.SetActive(false);
            failedText.SetActive(true);
        }
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
            lifesText.color = fullLife;
        }
        else if (life <= treeQuarLife && life > twoQuarLife)
        {
            lifesPng.color = treeQuarters;
            lifesText.color = treeQuarters;
        }
        else if (life <= twoQuarLife && life > oneQuarLife)
        {
            lifesPng.color = twoQuarters;
            lifesText.color = twoQuarters;
        }
        else if (life <= oneQuarLife && life > 0)
        {
            lifesPng.color = oneQuarters;
            lifesText.color = oneQuarters;
        }

        lifesText.text = life.ToString();
    }

    public void TotalPoints(int amount)
    {
        points += amount;

        pointsText.text = points.ToString();
    }

    private void LateUpdate()
    {
        timeSecondsText.text = Mathf.Floor(GameManager.instance.secondsClock).ToString();

        timeMinutesText.text = GameManager.instance.minutesClock.ToString();
    }
}
