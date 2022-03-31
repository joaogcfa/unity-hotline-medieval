using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public GameObject mainChar;
    public Animator mainCharAnimator;
    public AudioSource audioSource;
    public bool powerUp;
    private float time;

    public float bulletForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        mainCharAnimator = mainChar.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        time = Time.time;
        powerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Time.time - time > .75) {
                if(powerUp) {
                    ShootPowerUp();
                } else {
                    Shoot();
                }
            }
        } 
        else
        {
            mainCharAnimator.SetBool("Attacking", false);
        }
    }

    void ShootPowerUp()
    {
        mainCharAnimator.SetTrigger("Attacking");
        time = Time.time;
        audioSource.Play();
        InstantiateBullet();
        StartCoroutine(Wait());
    }

    void Shoot()
    {
        mainCharAnimator.SetTrigger("Attacking");
        time = Time.time;
        audioSource.Play();
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position + new Vector3(1.0f,1.0f,0), firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    void InstantiateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position + new Vector3(1.0f,1.0f,0), firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.25f);
        InstantiateBullet();
        yield return new WaitForSeconds(0.25f);
        InstantiateBullet();
    }
}
