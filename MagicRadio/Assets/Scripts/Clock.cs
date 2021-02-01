using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float shijianxianzhi = 9600;
    public static Clock Instance;
    public Text daojishi;
    [Header("显示时间")]
    public Text DayUI;
    public Text HourUI;
    public Text MinUI;
    private void Awake()
    {
        Instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        daojishi11();
    }
    public void daojishi11()
    {
        shijianxianzhi -= Time.deltaTime;
        daojishi.text = (shijianxianzhi / 60).ToString("0.0")+"小时";
    }
    public void SetTargetTimeUI(DateTime TargetHistoryDateTime)
    {
        float a = TargetHistoryDateTime.Day - TargetHistoryDateTime.Day % 1;
        float b = TargetHistoryDateTime.Hour - TargetHistoryDateTime.Hour % 1;
        float c = TargetHistoryDateTime.Minute - TargetHistoryDateTime.Minute % 1;
        DayUI.text = a.ToString("0");
        HourUI.text = b.ToString("0");
        MinUI.text = c.ToString("0");
    }
}
