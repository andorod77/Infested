using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunManager : MonoBehaviour {

    Image gunImage;
    public Image icon;
    float ammo;
    GameObject player;
    PlayerManager playerManager;
    GunSwitch gunSwitch;
    Color tmp;
  
    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");
        playerManager = player.GetComponent<PlayerManager>();
        gunSwitch = player.GetComponent<GunSwitch>();
        gunImage = GetComponent<Image>();
        tmp = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update() {


    }

     public void ShotGun()
    {

        if (Mathf.Round(playerManager.points) >= 30f)
        {
            Soundmanager.PlaySound("Buy");
            playerManager.points -= 30f;
            gunSwitch.hasShotGun = true;
            gunSwitch.hasGun = gunSwitch.hasRifle = gunSwitch.hasSniper = gunSwitch.hasNuke = false;
            


            GunSwitch.temp = 0;

           gunSwitch.weaponList[0] += 20;
      

        } else
        {

            StartCoroutine(Red());

        }


        }

    public void Rifle()
    {

        if (Mathf.Round(playerManager.points) >= 55f)
        {
            Soundmanager.PlaySound("Buy");
            playerManager.points -= 55f;
            gunSwitch.hasRifle = true;
            gunSwitch.hasGun = gunSwitch.hasShotGun = gunSwitch.hasSniper = gunSwitch.hasNuke = false;

            GunSwitch.temp = 1;

            gunSwitch.weaponList[1] += 100;

        }
        else
        {

            StartCoroutine(Red());

        }
    }

    public void Sniper()
    {

        if (Mathf.Round(playerManager.points) >= 70f)
        {
            Soundmanager.PlaySound("Buy");
            playerManager.points -= 70f;
            gunSwitch.hasSniper = true;
            gunSwitch.hasGun = gunSwitch.hasShotGun = gunSwitch.hasRifle = gunSwitch.hasNuke = false;



            GunSwitch.temp = 2;

            gunSwitch.weaponList[2] += 25;



        }
        else
        {

            StartCoroutine(Red());

        }
    }

    public void Nuke()
    {

        if (Mathf.Round(playerManager.points) >= 100f)
        {
            Soundmanager.PlaySound("Buy");
            playerManager.points -= 100f;
            gunSwitch.hasNuke = true;
            gunSwitch.hasGun = gunSwitch.hasShotGun = gunSwitch.hasRifle = gunSwitch.hasSniper = false;


            GunSwitch.temp = 3;


            gunSwitch.weaponList[3] += 5;


        }
        else
        {

            StartCoroutine(Red());

        }
    }

    IEnumerator Red()
    {
        tmp = Color.red;
        gunImage.color = tmp;
        icon.color = tmp;
        yield return new WaitForSecondsRealtime(0.13f);
        tmp = Color.white;
        gunImage.color = tmp;
        icon.color = tmp;
    


    }
}
