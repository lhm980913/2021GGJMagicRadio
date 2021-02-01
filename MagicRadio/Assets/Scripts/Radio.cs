using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Radio : MonoBehaviour
{
    public static Radio Instance;
    public Button HzButton;
    public Button DateButton;
    public Button TimeButton;
    public Text HzText;

    float _hz;
    public float MinHz;
    public float MaxHz;
    public float Hz
    {
        set
        {
            _hz = Mathf.Clamp(value, MinHz, MaxHz);
        }
        get
        {
            return _hz;
        }
    }

    public GameObject HzBar;
    public DateTime NowTime;

    [Header("历史回溯模式")]
    public bool HistoryMode = false;
    public Slider HistoryModeUI;
    public DateTime TargetHistoryDateTime;
    public Text DayUI;
    public Text HourUI;
    public Text MinUI;
    [Header("信息数据")]
    public RadioMessages RadioMessages;
    public TalkMessages TalkMessages;
    public NarrationMessages NarrationMessages;


    float NowTimeTimeCount =0;
    // Start is called before the first frame update
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        NowTimeTimeCount = 0;
        TalkMessages.init();
        NarrationMessages.init();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HzText.text = Hz.ToString("0.0");
        HzBar.transform.localPosition = new Vector3(-13.5f + 27 * ((Hz - MinHz) / (MaxHz - MinHz)), 0, 0);

        if(HistoryModeUI.value==0&&HistoryMode!=false)
        {
            HistoryMode = false;
            AudioController.Instance.TryPlayAudio(AudioType.收音机开关);
        }
        else if (HistoryModeUI.value == 1 && HistoryMode == false)
        {
            HistoryMode = true;
            AudioController.Instance.TryPlayAudio(AudioType.收音机开关);
        }

        if(HzButton.Select/*||TimeButton.Select||DateButton.Select*/)
        {
            CheckRadioMessage();
        }

        //更新现在的时间，并且检测有没有旁边或者事件对话
        NowTimeTimeCount += Time.deltaTime;
        if(NowTimeTimeCount>1)
        {
            NowTimeTimeCount = 0;
            UpdateNowTime();
        }
    }
    public void UpdateNowTime()
    {
        NowTime.Minute += 1;
        CheckTalkAndNarration();
    }
    public void CheckTalkAndNarration()
    {
        foreach (TalkMessageData talkMessage in TalkMessages.talkMessageDatas)
        {
            
            if(!talkMessage.BeginTime.IsLaterThanOtherDateTimeSameDay(NowTime) && !talkMessage.Talked&&!talkMessage.IsEventMessage)
            {
                talkMessage.Talked = true;
                GameUI.Instance.UpdateTalkMessage(talkMessage);
            }
        }
        foreach (NarrationMessageData narrationMessageData in NarrationMessages.NarrationMessageDatas)
        {
         
            if (!narrationMessageData.BeginTime.IsLaterThanOtherDateTimeSameDay(NowTime) && !narrationMessageData.Talked && !narrationMessageData.IsEventMessage)
            {
                narrationMessageData.Talked = true;
                GameUI.Instance.UpdateNarrationMessage(narrationMessageData);
            }
        }
    }

  
    public void SetTargetTimeUI()
    {
        float a=    TargetHistoryDateTime.Day - TargetHistoryDateTime.Day % 1;
        float b =   TargetHistoryDateTime.Hour - TargetHistoryDateTime.Hour % 1;
        float c =  TargetHistoryDateTime.Minute - TargetHistoryDateTime.Minute % 1;
        
        DayUI.text = a.ToString("0");
        HourUI.text = b.ToString("0");
        MinUI.text = c.ToString("0");
    }

    public void CheckRadioMessage()
    {

        foreach (RadioMessageData radioMessage in RadioMessages.radioMessageDatas)
        {
            if(Hz> radioMessage.Hz&&Hz< radioMessage.Hz + 1)
            {
  
                if(HistoryMode)
                {
                    if(CheckRadioTime(TargetHistoryDateTime,radioMessage.BeginTime,radioMessage.EndTime,radioMessage.EveryDay))
                    {
                     
                        GameUI.Instance.UpdateRadioMessage(radioMessage);
                        return;
                    }
                }
                else
                {
                    if (CheckRadioTime(NowTime, radioMessage.BeginTime, radioMessage.EndTime, radioMessage.EveryDay))
                    {

                        GameUI.Instance.UpdateRadioMessage(radioMessage);
                        return;
                    }
                }
            }
            else
            {
                GameUI.Instance.IsTrue = false;
            }
        }
    }

    public bool CheckRadioTime(DateTime RadioTime,DateTime begTime,DateTime endTime,bool EveryDay = false)
    {
        if(RadioTime.IsLaterThanOtherDateTime(begTime, EveryDay) &&!RadioTime.IsLaterThanOtherDateTime(endTime, EveryDay))
        {
            return true;
        }
        else
        {
            GameUI.Instance.IsTrue = false;
            return false;
        }

    }


}
