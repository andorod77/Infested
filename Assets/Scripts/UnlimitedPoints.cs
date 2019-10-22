using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlimitedPoints : MonoBehaviour {
    public GameObject player;
    PlayerManager playerManager;
	// Use this for initialization
	void Start () {
        playerManager = player.GetComponent<PlayerManager>();

    }
	
	// Update is called once per frame
	void Update () {
      
    }

    public void GetPoints()
    {
        playerManager.points = 999;
    }
}
