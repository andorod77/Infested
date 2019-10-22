using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Animator anim;
    public Image black;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
      

    }
    public void PlayGame()
    {

        StartCoroutine(Fading());
        

    }

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
