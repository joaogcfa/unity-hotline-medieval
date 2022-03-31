using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atackPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject Player;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Player.layer)
        {
            audioSource.Play();
            anim.SetTrigger("Attack");
            anim.SetBool("canWalk", false);

        }
        else
        {
            anim.SetTrigger("canWalk");
            anim.SetBool("Attack", false);
        }
    }


}
