using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AG_Shake : MonoBehaviour {

	// Use this for initialization
	void Start () {
        iTween.ScaleTo(gameObject, iTween.Hash("scale",new Vector3(.8f,.8f,.8f), "loopType", iTween.LoopType.pingPong,"time",.5f));
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
