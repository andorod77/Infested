using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour {

    public static AudioClip gunSound, bloodSound, shotgunSound, sniperSound, nukeSound, buySound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        gunSound = Resources.Load<AudioClip>("GunSound");
        bloodSound = Resources.Load<AudioClip>("Blood");
        shotgunSound = Resources.Load<AudioClip>("ShotgunSound");
        sniperSound = Resources.Load<AudioClip>("SniperSound");
        nukeSound = Resources.Load<AudioClip>("Nuke");
        buySound = Resources.Load<AudioClip>("Buy");

        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "GunSound":
                audioSrc.PlayOneShot(gunSound);
                break;

            case "Blood":
                audioSrc.PlayOneShot(bloodSound);
                break;

            case "ShotgunSound":
                audioSrc.PlayOneShot(shotgunSound);
                break;

            case "SniperSound":
                audioSrc.PlayOneShot(sniperSound);
                break;

            case "Nuke":
            audioSrc.PlayOneShot(nukeSound);
            break;

            case "Buy":
            audioSrc.PlayOneShot(buySound);
            break;
        }
    }
}
