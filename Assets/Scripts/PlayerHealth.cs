using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public GameObject[] lives;
    public Animator playerAnimator;
    public SpriteRenderer playerRenderer;
    public AudioSource audioSource;
    int contadorLives = 0;

    int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("colisao");
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "hitBox")
        {
            audioSource.Play();
            lives[contadorLives].SetActive(false);
            contadorLives++;
            health -= 25;
            if (health <= 0)
            {
                StartCoroutine(TriggerDeath());
            }
            print("health: " + health);
            playerAnimator.SetTrigger("Hit");
            playerRenderer.color = new Color(1, 0, 0, 1);
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hitBox")
        {
            playerAnimator.SetBool("Hit", false);
            StartCoroutine(ChangeColor());
        } 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TriggerDeath() {
        playerAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Credits");
    }

    IEnumerator ChangeColor() {
        yield return new WaitForSeconds(0.2f);
        playerRenderer.color = new Color(1, 1, 1, 1);
    }
}
