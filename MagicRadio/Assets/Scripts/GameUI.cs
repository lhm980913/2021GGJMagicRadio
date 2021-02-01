using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    public GameObject DuiHuaKuang;
    public Text TalkerName;
    public Text Message;
    public Image TalkerTex;
    [Header("计时器")]
    float timecount = 0;
    public bool IsTrue;

    public MessageTextData[] messageTextDatas;
    public int nowMessageIndex = 0;
    public DataTpye NowMessageTpye;

    public UnityEvent nextMessage;

    public SpriteRenderer Letter;
    public SpriteRenderer Map;
    public SpriteRenderer Paper;
    public Canvas canvas;

    public Image LetterButton;
    public Image MapButton;
    public Image PaperButton;

    public Image Renwu;
    [Header("所有频段")]
    public Text[] Sths;
    public GameObject Final;
    [Header("场景一")]
    public SpriteRenderer AnSeBeijing;
    public AnimationCurve ac;
    public SpriteRenderer Dead;
    public SpriteRenderer Bleed;
    public SpriteRenderer radiosprite;
    public SpriteRenderer paperandletter;
    public SpriteRenderer map;
    public SpriteRenderer hand;

    public bool PlayDianliu = false;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        SetButtonsActive(false,LetterButton);
        SetButtonsActive(false, MapButton);
        SetButtonsActive(false, PaperButton);
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetButtonsActive(bool Value,Image image)
    {
        image.gameObject.SetActive(Value);
     
    }
    public void finalButton()
    {
        if(Final.activeSelf)
        {
            Final.SetActive(false);
        }
        else
        {
            Final.SetActive(true);
        }
    }
    public void PressButton(int index)
    {
        GameManager.Instance.TurnGameState(GameState.RadioScene);
        AudioController.Instance.TryPlayAudio(AudioType.切换场景或者道具);
        switch (index)
        {
            case 1:
                {
                    Letter.sortingOrder = 2;
                    Map.sortingOrder = 1;
                    Paper.sortingOrder = 1;
                    canvas.sortingOrder = 1;
                    if (Radio.Instance.transform.position.z==-100)
                    {
                        GameUI.Instance.UpdateMessage(Radio.Instance.NarrationMessages.NarrationMessageDatas[3]);
                 
                    }
                }
                break;
            case 2:
                {
                    Letter.sortingOrder = 1;
                    Map.sortingOrder = 2;
                    Paper.sortingOrder = 1;
                    canvas.sortingOrder = 1;
                }
                break;
            case 3:
                {
                    Letter.sortingOrder = 1;
                    Map.sortingOrder = 1;
                    Paper.sortingOrder = 2;
                    canvas.sortingOrder = 2;
                }
                break;
            default:
                break;
        }
   
    }
    // Update is called once per frame
    void Update()
    {
        
        if (IsTrue)
        {
            
            timecount += Time.deltaTime;
        }
        else if (!IsTrue&& NowMessageTpye== DataTpye.Radio&& DuiHuaKuang.activeSelf)
        {
            CloseRadioMessage();
        }
        if(timecount>1&& IsTrue)
        {
            if(PlayDianliu)
            {
                AudioController.Instance.TryPlayAudio(AudioType.收音机电流1s);
                PlayDianliu = false;
            }
           
            UpdateDuihuakuangMessage();
        }
        else
        {
            PlayDianliu = true;
        }

        tianguang();
    }
    public void tianguang()
    {
        Color c = AnSeBeijing.color;
        float a = (Radio.Instance.NowTime.Hour/24)+ Radio.Instance.NowTime.Minute/(24*60);
        c.a = ac.Evaluate(a);
      
        AnSeBeijing.color = c;
    }
    public void UpdateNarrationMessage(NarrationMessageData MessageData)
    {
        NowMessageTpye = DataTpye.Narration;
        messageTextDatas = MessageData.MessageTexts;
        nowMessageIndex = 0;
        nextMessage = MessageData.NextMessageEvent;
        UpdateDuihuakuangMessage();

    }
    public void UpdateTalkMessage(TalkMessageData MessageData)
    {
  
        NowMessageTpye = DataTpye.Talk;
        messageTextDatas = MessageData.MessageTexts;

        nowMessageIndex = 0;
        nextMessage = MessageData.NextMessageEvent;
        UpdateDuihuakuangMessage();
     
    }
    public void UpdateRadioMessage(RadioMessageData MessageData)
    {
        nextMessage = MessageData.NextMessageEvent;
        NowMessageTpye = DataTpye.Radio;
        IsTrue = true;

        messageTextDatas = MessageData.MessageTexts;
        nowMessageIndex = 0;
    }
    public void UpdateMessage(MessageData MessageData)
    {
        if(MessageData is TalkMessageData)
        {
            NowMessageTpye = DataTpye.Talk;
        }
        else if(MessageData is NarrationMessageData)
        {
            NowMessageTpye = DataTpye.Narration;
        }
        messageTextDatas = MessageData.MessageTexts;
        nowMessageIndex = 0;
        nextMessage = MessageData.NextMessageEvent;
        UpdateDuihuakuangMessage();
    }
    public void UpdateDuihuakuangMessage()
    {
       
        DuiHuaKuang.SetActive(true);
      
        Message.text = messageTextDatas[nowMessageIndex].MessageText;
        if(messageTextDatas[nowMessageIndex].Talker)
        {
            TalkerName.text = messageTextDatas[nowMessageIndex].Talker.TalkerName;
            TalkerTex.sprite = messageTextDatas[nowMessageIndex].Talker.TalkerTex;
        }

    }
    public void NextMessage()
    {
        nowMessageIndex++;
        UpdateDuihuakuangMessage();
        AudioController.Instance.TryPlayAudio(AudioType.鼠标点击对话);
    }
    public void CloseRadioMessage()
    {
        IsTrue = false;
        DuiHuaKuang.SetActive(false);
        timecount = 0;
        if(nextMessage.GetPersistentEventCount()!=0)
        {
            nextMessage.Invoke();
        }
        AudioController.Instance.TryPlayAudio(AudioType.鼠标点击对话);
    }
    
}
///TODO:
///0、死掉的人和血迹出现
///1、送饭的人来送饭的走
///2、报纸和信封
///3、收音机和地图
///4、音效和人物头像
///5、任务的选择题和关卡的游戏结果
///6、优化
///         音效列表
///         1、bgm
///         2、鼠标点击对话声音
///         3、枪毙、
///         4、人倒地
///         5、获得东西
///         6、敲门送东西
///         7、切换地图letter的音效
///         8、记笔记的声音
///         9、收音机:电流声，旋钮持续音效，开关switch音效
///         10、脚步声
///         11、汽车引擎