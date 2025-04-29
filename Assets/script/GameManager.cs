using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStarted;
    public GameObject platformSpawner;
    [Header("GaameOver")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI lastScoreText;


    [Header("Score")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestTex;
    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI starText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }//awake
    // Start is called before the first frame update
    void Start()
    {
        //total diamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text= totalDiamond.ToString();

        //total star
        totalStar = PlayerPrefs.GetInt("totalStar");
        starText.text = totalStar.ToString();
        //bestscore
        bestScore =PlayerPrefs. GetInt("bestScore");
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        } 
    }
    public void GameStart()
    {
        isGameStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);

        if (score > bestScore)
        {
        PlayerPrefs.SetInt("bestScore",score);
        }



    }//gameover

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if(score > bestScore)
            {
                bestTex.text = score.ToString();
            }
            scoreText.text = score.ToString();
            
           
        }
    }//updatescore

    public void ReplayGame()
    {
        SceneManager.LoadScene("1");
    }
    public void GetStar()
    {
        int newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", totalStar);
        starText.text = totalStar.ToString();
    }
    public void GetDiamond()
    {
        int newDiamond = totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", totalDiamond);
        diamondText.text = totalDiamond.ToString();
    }
}
