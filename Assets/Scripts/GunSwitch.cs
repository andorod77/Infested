using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSwitch : MonoBehaviour {

    Animator anim;
    PlayerManager playerManager;
    Vector2 bulletPos;
    public GameObject bulletToRight, bulletToLeft, shotgunBulletToRight, shotgunBulletToLeft;
    float nextFireSh, nextFireR, nextFireS, nextFireG = 0.0f;
    float shotGunFireRate = 1.35f;
    float rifleFireRate = 0.2f;
    float sniperFireRate = 2.25f;
    float gunFireRate = 0.525f;
    public bool hasShotGun, hasRifle, hasSniper, hasNuke, hasGun;
    int shotGunAmmo = 0;
    int rifleAmmo = 0;
    int sniperAmmo = 0;
    int nukeAmmo = 0;
    GameObject[] gameObjects;
    Image nukeHit;
    public static int temp = -1;
    List<bool> boolList;
    public List<int> weaponList;
    public Image gunImage;
    public Text ammo;
    public Sprite shotGunImage;
    public Sprite rifleImage;
    public Sprite sniperImage;
    public Sprite nukeImage;
    public Sprite gun_image;
    GameObject fireBullet;
    public CanvasGroup nukeEffect;
    bool nuke = false;
    public NukeImpact nukeImpact;
   
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();

        hasGun = true;
        hasShotGun = hasRifle = hasSniper = hasNuke = false;
        gunImage.sprite = gun_image;
        ammo.text = "";

        shotGunImage = Resources.Load<Sprite>("shotgun pic");
        rifleImage = Resources.Load<Sprite>("Machine gun");
        sniperImage = Resources.Load<Sprite>("sniper pic");
        nukeImage = Resources.Load<Sprite>("Nuke pic");
        gun_image = Resources.Load<Sprite>("Mockup 3");

        weaponList = new List<int>();
        boolList = new List<bool>();

        weaponList.Add(shotGunAmmo);
        weaponList.Add(rifleAmmo);
        weaponList.Add(sniperAmmo);
        weaponList.Add(nukeAmmo);

        boolList.Add(hasShotGun);
        boolList.Add(hasRifle);
        boolList.Add(hasSniper);
        boolList.Add(hasNuke);
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("Gun", hasGun);
        anim.SetBool("Shotgun", hasShotGun);
        anim.SetBool("Assault", hasRifle);
        anim.SetBool("Sniper", hasSniper);
        anim.SetBool("Nuke", hasNuke);

        if (!playerManager.paused)
        {
            if (hasGun == true && Input.GetButtonDown("Fire1") && playerManager.isRunning == false && Time.time > nextFireG)
            {
                nextFireG = Time.time + gunFireRate;
                StartCoroutine(FireGun());



            }
            else if (hasShotGun == true && Input.GetButtonDown("Fire1") && playerManager.isRunning == false && Time.time > nextFireSh && weaponList[0] != 0)
            {
                nextFireSh = Time.time + shotGunFireRate;
                StartCoroutine(FireShotGun());
            }
            else if (hasRifle == true && Input.GetButton("Fire1") && playerManager.isRunning == false && Time.time > nextFireR && weaponList[1] != 0)
            {
                nextFireR = Time.time + rifleFireRate;
                StartCoroutine(FireRifle());
            }
            else if (hasSniper == true && Input.GetButtonDown("Fire1") && playerManager.isRunning == false && Time.time > nextFireS && weaponList[2] != 0)
            {
                nextFireS = Time.time + sniperFireRate;
                StartCoroutine(FireSniper());

            }
            else if (hasNuke == true && Input.GetButtonDown("Fire1") && weaponList[3] != 0)
            {
                Nuke();
            }


            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                if (hasGun == true)
                {
                    for (int i = 0; i < weaponList.Count; i++)
                    {
                        if (weaponList[i] > 0)
                        {
                            temp = i;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < boolList.Count; i++)
                    {
                        if (boolList[i] == true)
                        {
                            int j = i + 1;
                            if (j == 4)
                            {
                                temp = -1;
                            }
                            else
                            {
                                while (j != 4)
                                {
                                    if (weaponList[j] > 0)
                                    {
                                        temp = j;
                                        break;
                                    }
                                    else
                                    {
                                        temp = -1;
                                        j++;
                                    }



                                }


                            }


                        }
                    }
                }


            }
        }

            if (temp == 0)
            {

                hasShotGun = true;
                hasGun = hasRifle = hasSniper = hasNuke = false;


                boolList[0] = true;
                boolList[1] = boolList[2] = boolList[3] = false;

                gunImage.sprite = shotGunImage;
                ammo.text = "" + weaponList[0];

            }
            else if (temp == 1)
            {
                hasRifle = true;
                hasGun = hasShotGun = hasSniper = hasNuke = false;

                boolList[1] = true;
                boolList[0] = boolList[2] = boolList[3] = false;
                gunImage.sprite = rifleImage;
                ammo.text = "" + weaponList[1];
            }
            else if (temp == 2)
            {

                hasSniper = true;
                hasGun = hasShotGun = hasRifle = hasNuke = false;

                boolList[2] = true;
                boolList[1] = boolList[0] = boolList[3] = false;
                gunImage.sprite = sniperImage;
                ammo.text = "" + weaponList[2];

            }
            else if (temp == 3)
            {
                hasNuke = true;
                hasGun = hasShotGun = hasRifle = hasSniper = false;

                boolList[3] = true;
                boolList[1] = boolList[2] = boolList[0] = false;
                gunImage.sprite = nukeImage;
                ammo.text = "" + weaponList[3];

            }
            else
            {
                hasGun = true;
                hasShotGun = hasRifle = hasSniper = hasNuke = false;
                gunImage.sprite = gun_image;
                ammo.text = "";
            }

        if (nuke)
        {

            nukeEffect.alpha -= Time.deltaTime * 0.88f;
            if (nukeEffect.alpha <= 0)
            {
                nukeEffect.alpha = 0;
                nuke = false;
            }
        }




    }

    IEnumerator FireShotGun()
    {
        weaponList[0]--; 
        anim.SetTrigger("Fire");
        yield return new WaitForSeconds(0.10f);
        Soundmanager.PlaySound("ShotgunSound");
        bulletPos = transform.position;
        if (playerManager.facingRight)
        {
            bulletPos += new Vector2(+1f, +0.09f);
            fireBullet = Instantiate(shotgunBulletToRight, bulletPos, Quaternion.identity);
            fireBullet.tag = "ShotgunBullet";
        }
        else
        {
            bulletPos += new Vector2(-1f, +0.09f);
            fireBullet = Instantiate(shotgunBulletToLeft, bulletPos, Quaternion.identity);
            fireBullet.tag = "ShotgunBullet";
        }
    }

    IEnumerator FireRifle()
    {
        weaponList[1]--;
        anim.SetTrigger("Fire");
        yield return new WaitForSeconds(0.10f);
        Soundmanager.PlaySound("GunSound");
        bulletPos = transform.position;
        if (playerManager.facingRight)
        {
            bulletPos += new Vector2(+1f, +0.09f);
            fireBullet = Instantiate(bulletToRight, bulletPos, Quaternion.identity);
            fireBullet.tag = "RifleBullet";
        }
        else
        {
           bulletPos += new Vector2(-1f, +0.09f);
            fireBullet = Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
            fireBullet.tag = "RifleBullet";
        }
    }

    IEnumerator FireSniper()
    {
        weaponList[2]--;
        anim.SetTrigger("Fire");
        yield return new WaitForSeconds(0.10f);
        Soundmanager.PlaySound("SniperSound");
        bulletPos = transform.position;
        if (playerManager.facingRight)
        {
            bulletPos += new Vector2(+1f, +0.09f);
            fireBullet = Instantiate(bulletToRight, bulletPos, Quaternion.identity);
            fireBullet.tag = "SniperBullet";
        }
        else
        {
            bulletPos += new Vector2(-1f, +0.09f);
            fireBullet = Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
            fireBullet.tag = "SniperBullet";
        }
    }

    IEnumerator FireGun()
    {
        anim.SetTrigger("Fire");
        yield return new WaitForSeconds(0.10f);
        Soundmanager.PlaySound("GunSound");
        bulletPos = transform.position;
        if (playerManager.facingRight)
        {
            bulletPos += new Vector2(+1f, +0.09f);
            fireBullet = Instantiate(bulletToRight, bulletPos, Quaternion.identity);
            fireBullet.tag = "Bullet";
        }
        else
        {
            bulletPos += new Vector2(-1f, +0.09f);
            fireBullet = Instantiate(bulletToLeft, bulletPos, Quaternion.identity);
            fireBullet.tag = "Bullet";
        }
    }

    void Nuke()
    {

        weaponList[3]--;
        nuke = true;
        nukeEffect.alpha = 1;
        nukeImpact.NukeShake(0.68f, 0.1f);

        Soundmanager.PlaySound("Nuke");

        gameObjects = GameObject.FindGameObjectsWithTag("Zombie");


        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }




}
