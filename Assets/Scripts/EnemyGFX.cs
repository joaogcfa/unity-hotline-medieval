using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator anim;

    // Update is called once per frame

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            anim.SetTrigger("canWalk");
            transform.localScale = new Vector3(-1f, 1f, 1f);

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            anim.SetTrigger("canWalk");
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
