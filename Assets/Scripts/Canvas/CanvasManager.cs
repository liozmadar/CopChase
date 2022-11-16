using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject endGameCard;
    public TextMeshProUGUI headerText;

    public TextMeshProUGUI timerScore;
    public TextMeshProUGUI copsDestroyed;
    public TextMeshProUGUI coneCollected;

    public TextMeshProUGUI bestScoreText;
    public int bestScoreCount;
    public TextMeshProUGUI mostCopsDestroyedText;
    public int mostCopsDestroyedCount;
    public TextMeshProUGUI mostConeCollectedText;
    public int mostConeCollectedCount;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTheBestScoreNumber();
    }
    public void TryAgainButton()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGameCardWin()
    {
        endGameCard.SetActive(true);
        headerText.text = "You win!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
    }
    public void EndGameCardLose()
    {
        endGameCard.SetActive(true);
        headerText.text = "Try again!";
        timerScore.text = Timer.instance.timerText.ToString();
        copsDestroyed.text = GameManager.instance.copsDestroyedNumber.ToString();
        coneCollected.text = Cones.instance.coneCollectedCount.ToString();
    }
    void MostConesCollectedCheck()
    {
        mostConeCollectedCount = Cones.instance.coneCollectedCount;
        PlayerPrefs.SetInt("Cones", mostConeCollectedCount);
    }
    void MostCopsDestroyed()
    {
        mostCopsDestroyedCount = GameManager.instance.copsDestroyedNumber;
        PlayerPrefs.SetInt("Cops", mostCopsDestroyedCount);
    }
    void BestScore()
    {
        bestScoreCount = Timer.instance.timerText;
        PlayerPrefs.SetInt("Score", bestScoreCount);
    }
    void CheckTheBestScoreNumber()
    {
        if (Cones.instance.coneCollectedCount > PlayerPrefs.GetInt("Cones"))
        {
            MostConesCollectedCheck();
        }
        else
        {
            mostConeCollectedText.text = PlayerPrefs.GetInt("Cones").ToString();
        }
        if (GameManager.instance.copsDestroyedNumber > PlayerPrefs.GetInt("Cops"))
        {
            MostCopsDestroyed();
        }
        else
        {
            mostCopsDestroyedText.text = PlayerPrefs.GetInt("Cops").ToString();
        }
        if (Timer.instance.timerText > PlayerPrefs.GetInt("Score"))
        {
            BestScore();
        }
        else
        {
            bestScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
}