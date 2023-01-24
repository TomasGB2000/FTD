using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
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
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player2;

    public int health = 100;

    public GameObject deathEffect;

    /***************************************************************************************
* Title: Stealth
* Author: BlackThornProd
* Date: 2018
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=GPrGg8UDB_E
***************************************************************************************/
    public float rotationSpeed;
    public float distance;

    void Start()
    {
        player2 = GameObject.FindGameObjectWithTag("Player2").transform;

        timeBtwShots = startTimeBtwShots;

        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, player2.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player2.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player2.position) < stoppingDistance && Vector2.Distance(transform.position, player2.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player2.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player2.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            _soundScript.playShootSound();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        /***************************************************************************************
* Title: Stealth
* Author: BlackThornProd
* Date: 2018
* Code version: N/A
* Availability: https://www.youtube.com/watch?v=GPrGg8UDB_E
***************************************************************************************/
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
        }

    }



    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
            _soundScript.playEnemyDeathSound();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        _soundScript.playEnemyDeathSound();
    }
}
