using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSelf : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 mousePos;
    public Camera cam;
    public GameObject aim;

    public Vector2 velocidade;
    public float speed = 10.0f;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter");
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");


        Vector3 desiredVelocity = inputX * transform.right + inputY * transform.forward;

        velocidade = new Vector2(inputX * speed, inputY * speed);
        //rb.MovePosition(rb.position + velocidade * Time.fixedDeltaTime);

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        aim.transform.position = mousePos;
        Vector2 lookDir = mousePos - new Vector2(player.transform.position.x, player.transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
