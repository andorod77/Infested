using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeImpact : MonoBehaviour {

    float impactDuraction;
    float impactPower;
    Vector3 originalPos;

    

    // Use this for initialization
    void Start () {
        originalPos = new Vector3(0f, 0f, -10f);
	}
	
	// Update is called once per frame
	void Update () {
        if (impactDuraction >= 0)
        {
            Vector2 impactPos = Random.insideUnitCircle * impactPower;
            transform.position = new Vector3(transform.position.x + impactPos.x, transform.position.y + impactPos.y, transform.position.z);
            impactDuraction -= Time.deltaTime;
        }
        if (impactDuraction < 0)
        {
            transform.position = originalPos;
        }

    }

    public void NukeShake(float duration, float power)
    {
        impactDuraction = duration;
        impactPower = power;
    }
}
