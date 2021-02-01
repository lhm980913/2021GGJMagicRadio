using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AudioType
{
    ///         1、bgm
    ///         2、鼠标点击对话声音??????
    ///         3、枪毙、
    ///         4、人倒地
    ///         5、获得东西
    ///         6、敲门送东西???
    ///         7、切换地图letter的音效
    ///         8、记笔记的声音
    ///         9、收音机:电流声，旋钮持续音效，开关switch音效
    ///         10、脚步声
    ///         11、汽车引擎
    ///     
    none,
    鼠标点击对话,
    开枪,
    获得道具,
    敲门送东西,
    切换场景或者道具,
    收音机电流1s,
    收音机旋钮,
    收音机开关,
    汽车引擎
}
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [Serializable]
    struct AudioAndVolume
    {
        public AudioClip audioClip;
        public float Volume;
        public float Speed;
    }
    [Serializable]
    struct AudioAndType
    {
        public AudioType type;
        public AudioAndVolume audioClip;
    }


    [SerializeField]
    private List<AudioAndType> audios;

    private Dictionary<AudioType, AudioAndVolume> AudioDictionary;
    private AudioSource audioSource;
    public void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        audioSource = GetComponent<AudioSource>();
        InitAudioDictionary();
    }
    private void Update()
    {
        //audioSource.pitch = Time.timeScale;
    }
    public bool isPlaying()
    {
        return audioSource.isPlaying;
    }
    void InitAudioDictionary()
    {
        AudioDictionary = new Dictionary<AudioType, AudioAndVolume>();
        foreach (var audio in audios)
        {
            AudioDictionary.Add(audio.type, audio.audioClip);
        }
    }
    public void TryPlayAudio(AudioType type)
    {
        AudioAndVolume temp;
        if (AudioDictionary.TryGetValue(type, out temp))
        {
            if (temp.audioClip == null)
            {
                Debug.LogError("你这个" + type.ToString() + "咋没声音啊？");
                return;
            }
            audioSource.pitch = temp.Speed;
            audioSource.volume = temp.Volume;
            audioSource.PlayOneShot(temp.audioClip);
        }
        else
        {

        }
    }
    //public void TryPlayAudio(AudioType type)
    //{
    //    AudioClip temp;
    //    if (AudioDictionary.TryGetValue(type, out temp))
    //    {
    //        audioSource.PlayOneShot(temp);
    //    }
    //    else
    //    {
    //        Debug.Log(type.ToString());
    //    }
    //}
}
