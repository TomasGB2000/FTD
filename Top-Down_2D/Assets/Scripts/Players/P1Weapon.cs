using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject soundManager;
    private SoundManager _soundScript;

    public float bulletForce = 10f;

    private void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            _soundScript.playShootSound();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
