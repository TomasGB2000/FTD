using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject soundManager;
    private SoundManager _soundScript;

    public void Start()
    {
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            _soundScript.playShootSound();
        }
    }

    public void Shoot()
    {
       RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

       if (hitInfo)
        {
           Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        }
    }
}
