using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMananger : MonoBehaviour
{
    static public int virusTotal = 0;
    static public int virusRemain = 0;
    public GameObject textObj;
    public Text virusCount;
    public GameObject timerObj;
    private Text timerText;
    private float timer = 40.00f;
    void Start()
    {
        virusCount = textObj.GetComponent <Text>();
        timerText = timerObj.GetComponent<Text>();
    }
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "" + Mathf.Round(timer);
        virusCount.text = virusRemain + " / " + virusTotal;
        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
