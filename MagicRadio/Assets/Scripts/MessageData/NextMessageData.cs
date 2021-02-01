using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NextMessageData", menuName = "NextMessageData", order = 1)]
public class NextMessageData : ScriptableObject
{



    public void NextMessageTalk(int index)
    {
        GameUI.Instance.UpdateMessage(Radio.Instance.TalkMessages.talkMessageDatas[index]);
    }
    public void NextMessageNarration(int index)
    {
        GameUI.Instance.UpdateMessage(Radio.Instance.NarrationMessages.NarrationMessageDatas[index]);
    }
    public void getLotsOfThings()
    {
        AudioController.Instance.TryPlayAudio(AudioType.获得道具);
        GameUI.Instance.SetButtonsActive(true, GameUI.Instance.LetterButton);
        GameUI.Instance.SetButtonsActive(true, GameUI.Instance.PaperButton);
        GameUI.Instance.paperandletter.enabled = true;
   
    }

    public void GetRadioAndMap()
    {
        GameUI.Instance.Renwu.gameObject.SetActive(true);
        Radio.Instance.transform.position += Vector3.forward * 100;
        GameUI.Instance.SetButtonsActive(true, GameUI.Instance.MapButton);
        GameUI.Instance.radiosprite.enabled = true;
        GameUI.Instance.map.enabled = true;
        AudioController.Instance.TryPlayAudio(AudioType.获得道具);
    }
    public void GetSTHsPinDuan(int sth)
    {
        GameUI.Instance.Sths[sth].enabled = true;
    }
    public void GetSTHsAllPinDuan()
    {
        foreach (Text item in GameUI.Instance.Sths)
        {
            item.enabled = true;
        }
    }
    public void KillNPC()
    {
        GameUI.Instance.Dead.enabled = true;
        GameUI.Instance.Bleed.enabled = true;
        AudioController.Instance.TryPlayAudio(AudioType.开枪);
    }
    public void songfan(bool value)
    {
        GameUI.Instance.hand.enabled = value;
    if(value)
        {
            AudioController.Instance.TryPlayAudio(AudioType.敲门送东西);
        }
    }
}
