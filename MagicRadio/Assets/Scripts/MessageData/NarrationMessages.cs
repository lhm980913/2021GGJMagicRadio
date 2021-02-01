using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NarrationMessages", menuName = "MessageData/NarrationMessages", order = 1)]
public class NarrationMessages : ScriptableObject
{
    public List<NarrationMessageData> NarrationMessageDatas;

    public void init()
    {
        foreach (NarrationMessageData item in NarrationMessageDatas)
        {
            item.Talked = false;
        }
    }
}
