using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    bool isPaused;
    GameObject PausePnl;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        PausePnl = GameObject.Find("PausePanel");
        PausePnl.SetActive(false);
    }
    public void RestartFunc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void PauseClick()
    {
        if (!PlayerMovement.isDead)
        {
            PausePnl.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void StopPause()
    {
        PausePnl.SetActive(false);
        Time.timeScale = 1;
    }
}
