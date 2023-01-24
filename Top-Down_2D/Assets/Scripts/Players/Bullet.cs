using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;
    // public float speed = 20f;
    //public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // rb.velocity = transform.right * speed;
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Enemy1 enemy1 = hitInfo.GetComponent<Enemy1>();
        if (enemy != null)
        {
            enemy.TakeDamage(25);
        }

        if (enemy1 != null)
        {
            enemy1.TakeDamage(25);
        }
        Destroy(gameObject);

        if (hitInfo.gameObject.tag == "Bullet")
        {
            Destroy(hitInfo.gameObject);
            _soundScript.playEnemyDeathSound();
        }

        if (hitInfo.gameObject.tag == "Pot")
        {
            Destroy(hitInfo.gameObject);
        }

        if (hitInfo.gameObject.tag == "Crate")
        {
            Destroy(hitInfo.gameObject);
        }
    }
}
