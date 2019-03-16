using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Hue/Sound", order = 1)]
public class Sound : ScriptableObject
{

    [Range(0,1)]
    public float volume;

    [Header("Game Sounds")]
    public AudioClip wrong;
    public AudioClip multipleBubble;
    public AudioClip singleBubble;
    public AudioClip flag;
    [Header("Menu Sounds")]
    public AudioClip click;
}
