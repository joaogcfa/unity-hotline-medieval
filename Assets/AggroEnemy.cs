using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroEnemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rigid;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter");
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 13) {
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
