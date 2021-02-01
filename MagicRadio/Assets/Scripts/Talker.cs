using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Talker", menuName = "Talker", order = 1)]
public class Talker : ScriptableObject
{
    public string TalkerName;
    public Sprite TalkerTex;
    public AudioType TalkerVoice;
}
