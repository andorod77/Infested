using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningZombie : MonoBehaviour
{
    public GameObject runZombie;
    Vector2 location;
    float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    float startWait;


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
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            location = new Vector2(transform.position.x, transform.position.y);
            Instantiate(runZombie, location, Quaternion.identity);

            yield return new WaitForSeconds(spawnWait);



        }
    }
}
