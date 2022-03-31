using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public Animator enemyAnimator;
    public SpriteRenderer enemyRenderer;
    public GameObject[] lives;
    public AudioSource deathSound;
    public AudioSource hitSound;
    int contadorLives = 0;

    int maxHealth = 100;

    void Start()
    {
        health = maxHealth;
        enemyAnimator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hitSound.Play();
            health -= 25;
            lives[contadorLives].SetActive(false);
            contadorLives++;
            if (health <= 0)
            {
                StartCoroutine(TriggerDeathAnim());
            }
            enemyAnimator.SetTrigger("enemyHit");
        } 
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Bullet")
        // {
            enemyAnimator.SetBool("enemyHit", false);
        // } 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator TriggerDeathAnim() {
        enemyAnimator.SetTrigger("enemyDeath");
        deathSound.Play();
        yield return new WaitForSeconds(0.9f);
        Destroy(gameObject);
    }
    IEnumerator ChangeColor() {
        yield return new WaitForSeconds(0.2f);
        enemyRenderer.color = new Color(1, 1, 1, 1);
    }
}
