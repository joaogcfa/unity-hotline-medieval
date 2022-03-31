using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class getkey : MonoBehaviour
{

    public Image noKey;
    public Image withKey;
    public AudioSource audiosource;

    public GameObject[] Enemies;


    // Start is called before the first frame update
    void Start()
    {
        withKey = GameObject.Find("WithKey").GetComponent<Image>();
        noKey = GameObject.Find("NoKey").GetComponent<Image>();
        withKey.enabled = false;

        audiosource = GetComponent<AudioSource>();

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(PlaySound());
            foreach (GameObject Enemy in Enemies)
            {
                Enemy.SetActive(true);
            }

        }
    }

    IEnumerator PlaySound() {
        audiosource.Play();
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("Portal").GetComponent<Next_Level>().gotKey = true;
        noKey.enabled = false;
        withKey.enabled = true;
        GameObject.Destroy(gameObject);
    }
}
