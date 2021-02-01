using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum DataTpye
{
    Radio,
    Talk,
    Narration,
    none
}


[System.Serializable]
public class MessageData
{
    public string MessageDescription;
    [SerializeField]
    public MessageTextData[] MessageTexts;
    public UnityEvent NextMessageEvent;

    public bool EveryDay;
    public bool IsEventMessage = false;
    public DateTime BeginTime;
 
   

}

[System.Serializable]
public struct MessageTextData
{
   
    public string MessageText;
    [SerializeField]
    public Talker Talker;

}
