using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public float speed = 2f;
    public GameObject blood, smallBlood, points;
    GameObject player;
	PlayerManager play;
    PowerUps powerUps;
    public float health = 40f;
    public static float sniperDmg = 90f;
    float dmg;
    Color tmp;
    float random;
    SpriteRenderer zombie;
    public float lifetime;


    

    // Use this for initialization
	void Start () {
		zombie = GetComponent<SpriteRenderer>();
        Destroy(gameObject, lifetime);
        player = GameObject.FindGameObjectWithTag("Player");
        powerUps = player.GetComponent<PowerUps>();
		play = player.GetComponent<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        random = Random.value;


    }



    void SniperDamage() {
        health -= sniperDmg;
    }

    void Damage()
    {
   
       health -= dmg;

    }

    void OnTriggerEnter2D(Collider2D other)
    { 

		if (other.gameObject.tag.Equals("Bullet") || other.gameObject.tag.Equals("RifleBullet"))
            {
                dmg = 20f;
                Damage();
                if (health > 0)
                {
                    Instantiate(smallBlood, transform.position, Quaternion.identity);
                    Soundmanager.PlaySound("Blood");
                    StartCoroutine(Hit());
                    Destroy(other.gameObject);
                }
                else
                {
                    Instantiate(blood, transform.position, Quaternion.identity);
                    Soundmanager.PlaySound("Blood");
                    Destroy(other.gameObject);
                    Destroy(gameObject);
				    play.killcount++;
				if (random > 0.97 && powerUps.triggered == false && powerUps.onField == false)
                {
                    Instantiate(points, transform.position, Quaternion.identity);
					powerUps.onField = true;
                }
            }

            }  else if (other.gameObject.tag.Equals("ShotgunBullet"))
            { 

                dmg = 40f;
                Damage();
                if (health > 0)
                {
                    Instantiate(smallBlood, transform.position, Quaternion.identity);
                    Soundmanager.PlaySound("Blood");
                    StartCoroutine(Hit());
                }
                else
                {
                    Instantiate(blood, transform.position, Quaternion.identity);
                    Soundmanager.PlaySound("Blood");
                    Destroy(gameObject);
				    play.killcount++;
				if (random > 0.97 && powerUps.triggered == false && powerUps.onField == false)
                {
                    Instantiate(points, transform.position, Quaternion.identity);
					powerUps.onField = true;
                }
            }

            } else if (other.gameObject.tag.Equals("SniperBullet"))
            {
           
                SniperDamage();

                if (sniperDmg == 0f)
                {
                    Destroy(other.gameObject);
                    sniperDmg = 90f;
                    return;
                }
                
                    if (health > 0)
                    {
                        Instantiate(smallBlood, transform.position, Quaternion.identity);
                        Soundmanager.PlaySound("Blood");
                        StartCoroutine(Hit());
                    }
                    else
                    {
                        Instantiate(blood, transform.position, Quaternion.identity);
                        Soundmanager.PlaySound("Blood");
                        Destroy(gameObject);
				        play.killcount++;
				if (random > 0.97 && powerUps.triggered == false && powerUps.onField == false)
                {
                    Instantiate(points, transform.position, Quaternion.identity);
					powerUps.onField = true;
                }
            }

                 sniperDmg -= 10f;

               

                }
            

           
       
    }

    IEnumerator Hit()
    {

        tmp = new Color(1f, 1f, 1f, 0.55f);
        zombie.color = tmp;
        yield return new WaitForSeconds(0.075f);
        tmp = new Color(1f, 1f, 1f, 1f);
        zombie.color = tmp;

    }

 
    }

    
