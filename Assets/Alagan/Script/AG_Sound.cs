using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Sound : MonoBehaviour {

    public static AG_Sound Instance;
    public Sound sound;
    void Start () {
        Instance = this;

    }
	
	public void soundFlag()
    {
        GetComponent<AudioSource>().PlayOneShot(sound.flag, sound.volume);
    }
    public void soundError()
    {
        GetComponent<AudioSource>().PlayOneShot(sound.wrong, sound.volume);
    }

    public void soundMultipleBubble()
    {
        GetComponent<AudioSource>().PlayOneShot(sound.multipleBubble, sound.volume);
    }
    public void soundSingleBubble()
    {
        GetComponent<AudioSource>().PlayOneShot(sound.singleBubble, sound.volume);
    }
}
