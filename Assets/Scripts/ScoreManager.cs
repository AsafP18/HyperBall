using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    float scoretime;
    float scoretimer;
    static int score;
    static TextMeshProUGUI scoretext;
    static TextMeshProUGUI scoredisplay;//score that shows in the end
    static TextMeshProUGUI highscoredisplay;
    static GameObject LosePanel;
    static string scorekey;
    void Start()
    {
        scoretimer = 0.5f;
        scoretext = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        LosePanel = GameObject.Find("LosePanel");
        LosePanel.SetActive(false);
        scorekey = "HighScore";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.gamerun==true)
        {
            if(Time.time>scoretime)
            {
                score += 30;
                scoretime = Time.time + scoretimer;
                scoretext.text = score.ToString();
            }
        }
    }
    public static void OpenLosePanel()
    {
        LosePanel.SetActive(true);
        scoretext.text = "";
        scoredisplay = GameObject.Find("DisplayScore").GetComponent<TextMeshProUGUI>();
        highscoredisplay = GameObject.Find("DisplayHighScore").GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.GetInt(scorekey) > score)
        {
            scoredisplay.text = "Your Score: " + score;
            highscoredisplay.text = "High Score: " + PlayerPrefs.GetInt(scorekey);
        }
        else
        {
            PlayerPrefs.SetInt(scorekey, score);
            scoredisplay.text = "Your Score: " + score;
            highscoredisplay.text = "New High Score!!!";
        }
    }

}
