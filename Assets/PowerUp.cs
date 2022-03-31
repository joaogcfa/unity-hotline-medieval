using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject playerCajado;
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            playerCajado.GetComponent<Shooting>().powerUp = true;
            Destroy(gameObject);
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCajado = GameObject.Find("Cajado");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
