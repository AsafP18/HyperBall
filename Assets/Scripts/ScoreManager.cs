using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    float scoretime;
    float scoretimer;
    int score;
    TextMeshProUGUI scoretext;
    void Start()
    {
        scoretimer = 0.5f;
        scoretext = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
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

}
