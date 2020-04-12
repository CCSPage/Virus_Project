using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{
    static public int virusTotal = 0;
    static public int virusRemain = 0;
    public GameObject textObj;
    private Text virusCount;
    public GameObject timerObj;
    private Text timerText;
    private float timer = 50.00f;

    void Start()
    {
        virusCount = textObj.GetComponent <Text>();
        timerText = timerObj.GetComponent<Text>();
    }

    void Update()
    {
        Timer();
        
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
        if (timer != 0)
        {
            timer -= Time.deltaTime;
        }
        timerText.text = "" + timer.ToString("N2");
        virusCount.text = virusRemain + " / " + virusTotal;
    }
}
