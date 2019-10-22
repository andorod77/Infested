using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


    public GameObject zombie, bigZombie;
    Vector2 location, bigZombieLocation;
    public float spawnMostWait;
    public float spawnLeastWait;
    public float leastMob;
    public float mostMob;
    float startWait;
    float spawnWait;
    float random;
    float timer = 0f;
    int count = 0;



    // Use this for initialization
    void Start()
    {


        startWait = Random.Range(spawnLeastWait, spawnMostWait);
        StartCoroutine(WaitSpawner());
    }

    // Update is called once per frame
    void Update()
    {

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        startWait = Random.Range(spawnLeastWait, spawnMostWait);
        random = Random.Range(0f, 100f);

        timer += 0.63f * Time.deltaTime;

    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            location = new Vector2(transform.position.x, transform.position.y);
            bigZombieLocation = new Vector2(transform.position.x, -3f);

            if (random < 25f || count > 10)
            {
                float mob = Random.Range(leastMob, mostMob);

                for (int i = 0; i < (int)mob; i++)
                {
                    Instantiate(zombie, location, Quaternion.identity);
                    yield return new WaitForSeconds(0.4f);

                }
                count = 0;
            }
            else if (timer >= 45 && random > 90f)
            {
                Instantiate(bigZombie, bigZombieLocation, Quaternion.identity);
            } else
            {
                Instantiate(zombie, location, Quaternion.identity);
                count++;
            }




            yield return new WaitForSeconds(spawnWait);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag.Equals("SniperBullet"))
        {
            Destroy(other.gameObject);

            Zombie.sniperDmg = 90f;
        }
    }
}


