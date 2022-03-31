using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public bool gotKey;
    public GameObject blue;

    // public int facingNumber;
    public int nextSceneLoad;

    // // public AudioSource abertura;
    // // public AudioSource pegoChave;

    // private bool toca;

    // // public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        gotKey = false;
        // toca = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gotKey)
        {

            blue.SetActive(true);

            // if(toca == true){
            //     pegoChave.Play();
            //     anim.SetBool("open", true);
            //     toca = false;
            // }
            // this.gameObject.layer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gotKey)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

}
