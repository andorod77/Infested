using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool gameShop = false;

    public GameObject weaponShop;
    public GameObject player;



	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (player != null) { 
            if (gameShop)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
        }
	}

    void Resume()
    {
        weaponShop.SetActive(false);
        Time.timeScale = 1f;
        gameShop = false;
    }

    void Paused()
    {
        weaponShop.SetActive(true);
        Time.timeScale = 0f;
        gameShop = true;
    }
}
