using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour {

    Animator anim;
    private float speed;
    public GameObject Restart, GameOver, GoBack;
    public float points = 0;
    public Text score;
    float velX;
    float velY;
    public float jumpForce = 600f;
    Rigidbody2D rigBod;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    bool onGround;
    public bool facingRight = true;
    bool isWalking = false;
    public bool isRunning = false;
    float fallMultiplier = 2.5f;
    public bool paused;
	public Text kills;
	public int killcount = 0;





    // Use this for initialization
	void Start () {
        score.text = "Survival points :" + points;
        Restart.SetActive(false);
        GameOver.SetActive(false);
        GoBack.SetActive(false);




        speed = 1.185f;
        anim = GetComponent<Animator>();
        rigBod = GetComponent<Rigidbody2D>();

        Zombie.sniperDmg = 90f;
    }

    // Update is called once per frame
    void Update() {
       

		if (Input.GetKey("escape")) {
			Application.Quit();

	     }

		if (Time.timeScale == 0f)
        {
            paused = true;
        } else
        {
            paused = false;
        }

  

        if (!paused)
        {
            velX = Input.GetAxisRaw("Horizontal");
            velY = rigBod.velocity.y;

            rigBod.velocity = new Vector2(velX * speed, velY);
        }


            if (velX != 0)
            {
                isWalking = true;
            }
            else
            {
                isWalking = false;
            }

            anim.SetBool("IsWalking", isWalking);

            onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            anim.SetBool("onGround", onGround);

            anim.SetBool("IsRunning", isRunning);

            if (Input.GetKey(KeyCode.LeftShift) && rigBod.velocity.x != 0)
            {
                isRunning = true;
                speed = 2.765f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || rigBod.velocity.x == 0)
            {
                isRunning = false;
                speed = 1.185f;
            }
        if (!paused)
        {
            if (Input.GetButtonDown("Jump") && onGround)
            {
                rigBod.velocity = new Vector2(rigBod.velocity.x, jumpForce);
            }
     
            points += 0.7f * Time.deltaTime;


        } else
        {
            points += 0;
        }
       

        score.text = "Survival points : " + Mathf.Round(points);
		kills.text = "Kills : " + killcount;


      
    }

    void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        } else if ( velX < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    void FixedUpdate()
    {
    if (rigBod.velocity.y < 0)
        {
            rigBod.gravityScale = fallMultiplier;
        } else
        {
            rigBod.gravityScale = 1f;
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Zombie") || col.gameObject.tag.Equals("Boundary"))
        {
            GameOver.SetActive(true);
            Restart.SetActive(true);
            GoBack.SetActive(true);
         


            StartCoroutine(Die());




        }
    }
    private IEnumerator Die()
    {


        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.6f);
        GunSwitch.temp = -1;
        Destroy(gameObject);
    }


}



