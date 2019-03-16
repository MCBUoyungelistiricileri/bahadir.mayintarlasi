using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_MenuSound : MonoBehaviour {

    public static AG_MenuSound Instance;
    public Sound sound;
	void Start () {
        Instance = this;

    }
	
	public void soundClick()
    {
        GetComponent<AudioSource>().PlayOneShot(sound.click,sound.volume);
    }
}
