using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyP : MonoBehaviour {

	PowerUps powerUps = null;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 7f);

		powerUps.onField = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject == null) {
			powerUps.onField = false;
		}
		
	}
}
