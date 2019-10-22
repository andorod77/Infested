using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawnerLeft : MonoBehaviour {

    public GameObject zombie;
    public SpriteRenderer fade;
    Vector2 location;
    public float spawnMostWait;
    public float spawnLeastWait;
    float startWait;
    float spawnWait;
    Color tmp;
    Color c;
    float timer = 0f;
    bool spawn = false;



    // Use this for initialization
    void Start()
    {


        startWait = Random.Range(spawnLeastWait, spawnMostWait);
        tmp = fade.color;
        tmp.a = 0f;
        fade.color = tmp;

    }

    // Update is called once per frame
    void Update()
    {

        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        startWait = Random.Range(spawnLeastWait, spawnMostWait);

        timer += 0.63f * Time.deltaTime;

        if (timer >= 30f && spawn == false)
        {
            StartCoroutine(WaitSpawner());
            spawn = true;
        }

    }

    IEnumerator WaitSpawner()
    {

        yield return new WaitForSeconds(startWait);

        while (true)
        {

            location = new Vector2(transform.position.x, transform.position.y);
            Color c = fade.material.color;
            c.a = 1f;
            fade.material.color = c;
            StartCoroutine(FadeIn());
            yield return new WaitForSeconds(0.65f);
            Instantiate(zombie, location, Quaternion.identity);
            c = fade.material.color;
            c.a = 0f;
            fade.material.color = c;


            yield return new WaitForSeconds(spawnWait);


        }
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            tmp = fade.color;
            tmp.a = f;
            fade.color = tmp;
            yield return new WaitForSeconds(0.05f);
        }




    }

}
