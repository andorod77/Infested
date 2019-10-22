using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {

    public GameObject powerUp;
    public Text power;
    PlayerManager player;
    float points;
    public bool triggered = false;
	public bool onField = false;

    // Use this for initialization
	void Start () {
        player = GetComponent<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {

        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PowerUp"))
        {
            Destroy(other.gameObject);

            StartCoroutine(DoublePoints());

            triggered = true;

			onField = false;

        }
    }

    IEnumerator DoublePoints()
    {
        points = Random.Range(10f, 20f);

        while (points > 0f)
        {
            player.points += 0.7f;

            points -= 1;
            power.text = "Double Points";
            yield return new WaitForSeconds(1f);
        }

        power.text = "";

        triggered = false;

  
    
    }

   

}
