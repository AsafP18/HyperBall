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
    TextMeshProUGUI scoretext;
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
        print(score);
        if (PlayerPrefs.GetInt(scorekey) > score)
        {
            print(PlayerPrefs.GetInt(scorekey));
        }
        else
        {
            print("High Score" + score);
            PlayerPrefs.SetInt(scorekey, score);
        }
    }

}
