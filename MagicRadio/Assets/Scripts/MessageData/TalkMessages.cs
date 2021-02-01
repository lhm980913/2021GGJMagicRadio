using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TalkMessages", menuName = "MessageData/TalkMessages", order = 1)]
public class TalkMessages : ScriptableObject
{
    public List<TalkMessageData> talkMessageDatas;
    public void init()
    {
        foreach (TalkMessageData item in talkMessageDatas)
        {
            item.Talked = false;
        }
    }
}
