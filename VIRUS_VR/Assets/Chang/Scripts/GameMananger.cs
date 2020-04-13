using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{
    static public int virusTotal = 0;
    static public int virusRemain = 0;
    public GameObject textObj;
    private Text virusCount;
    public GameObject timerObj;
    private Text timerText;
    public GameObject scoreObj;
    private Text scoreText;
    public GameObject scorePanel;

    public GameObject fps;
    private FirstPersonAIO fpsScript;

    private float timer = 50.00f;
    static public bool gameOver = false;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        
        scorePanel.SetActive(false);
        virusCount = textObj.GetComponent <Text>();
        timerText = timerObj.GetComponent<Text>();
        scoreText = scoreObj.GetComponent<Text>();
        fpsScript = fps.GetComponent<FirstPersonAIO>();
        fpsScript.enabled = true;
    }

    void Update()
    {
        Timer();
        if (timer == 0) {
            GameOver();
        }
        if (virusRemain == 0) {
            GameOver();
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void Timer() {
        if (timer < 0)
        {
            timer = 0;
        }
        if (timer != 0 && virusRemain>0)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = "" + timer.ToString("N2");
        virusCount.text = virusRemain + " / " + virusTotal;
    }
    void GameOver() {
        scoreText.text = "Score: " + Mathf.Round(timer*virusTotal + (virusTotal-virusRemain)*10 + virusTotal*10);
        scorePanel.SetActive(true);
        gameOver = true;
        fpsScript.enabled = false;
        Time.timeScale = 0.1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void RestartButton() 
    {
        virusRemain = 0;
        virusTotal = 0;
        fpsScript.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       //Application.LoadLevel("Chang");
        SceneManager.LoadScene("Chang");

    }
    public void MenuButton() {
        //Application.LoadLevel(sceneName);
        Debug.Log("Menu");
    }
}
