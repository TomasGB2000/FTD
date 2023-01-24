using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    /***************************************************************************************
* Title: Patrolling AI
* Author: Mike Scriven
* Date: 2020
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=rn3tCuGM688&t=104s
***************************************************************************************/

    public float walkSpeed;

    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D enemyBody;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        enemyBody.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, enemyBody.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed += -1;
        mustPatrol = true;
    }
}
