using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject Player;

    void Start(){
        Player = GameObject.Find("MainCharacter");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == Player.layer){
            ;
        }
        else{
            Destroy(gameObject);
        }
    }
}
