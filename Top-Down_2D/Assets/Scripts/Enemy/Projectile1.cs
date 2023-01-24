using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile1 : MonoBehaviour
{

    public GameObject soundManager;
    private SoundManager _soundScript;
    /***************************************************************************************
* Title: Follow/Retreat AI
* Author: BlackThornProd
* Date: 2017
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=_Z1t7MNk0c4
***************************************************************************************/

    public float speed;

    public Transform player2;
    private Vector2 target;

    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        target = new Vector2(player2.position.x, player2.position.y);

        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
            _soundScript.playShootSound();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

        if (other.CompareTag("Player2"))
        {
            DestroyProjectile();
        }
    }

    void OnTriggerCollision2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pot")
        {
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Crate")
        {
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Wall")
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
