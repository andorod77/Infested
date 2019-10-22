using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioSource BackgroundMusic;
	// Use this for initialization
	void Start () {
        BackgroundMusic = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("m"))
        {
            BackgroundMusic.mute = !BackgroundMusic.mute;
        }
        
	}
}
