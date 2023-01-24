using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{  //Assigning Audio to Events
    private AudioSource _soundSource;
    private AudioClip _shootSound;
    private AudioClip _enemydeathSound;
    private AudioClip _cratebrakeSound;
    private AudioClip _potbrakeSound;
    private AudioClip _winSound;
    private AudioClip _loseSound;
    private AudioClip _backgroundSound;
    private AudioClip _gruntSound;
    private AudioClip _keySound;
    private AudioClip _keySound1;
    private AudioClip _healSound;

    void Start()
    {   //Assigning Sound Clips to assigned events
        _soundSource = GetComponent<AudioSource>();
        _shootSound = Resources.Load("Lmg_fire 01") as AudioClip;
        _enemydeathSound = Resources.Load("deathr") as AudioClip;
        _potbrakeSound = Resources.Load("291369-porcelainplatesinclothbag14") as AudioClip;
        _cratebrakeSound = Resources.Load("Tissue Out Of Box SFX") as AudioClip;
        _winSound = Resources.Load("win music 2") as AudioClip;
        _loseSound = Resources.Load("Icy Game Over") as AudioClip;
        _backgroundSound = Resources.Load("_background") as AudioClip;
        _gruntSound = Resources.Load("gruntsound") as AudioClip;
        _keySound = Resources.Load("Key Jiggle") as AudioClip;
        _keySound1 = Resources.Load("key_pickup") as AudioClip;
        _healSound = Resources.Load("healspell1") as AudioClip;
    }


    void Update()
    {

    }
    //Assigning Clips to be used in other scripts
    public void playShootSound()
    {
        _soundSource.PlayOneShot(_shootSound);
    }

    public void playEnemyDeathSound()
    {
        _soundSource.PlayOneShot(_enemydeathSound);
    }

    public void playPotBrakeSound()
    {
        _soundSource.PlayOneShot(_potbrakeSound);
    }

    public void playCrateBrakeSound()
    {
        _soundSource.PlayOneShot(_cratebrakeSound);
    }

    public void playWinSound()
    {
        _soundSource.PlayOneShot(_winSound);
    }

    public void playLoseSound()
    {
        _soundSource.PlayOneShot(_loseSound);
    }

    public void playBackgroundSound()
    {
        _soundSource.PlayOneShot(_backgroundSound);
    }

    public void playGruntSound()
    {
        _soundSource.PlayOneShot(_gruntSound);
    }

    public void playKeySound()
    {
        _soundSource.PlayOneShot(_keySound);
    }

    public void playKeyPickUpSound()
    {
        _soundSource.PlayOneShot(_keySound1);
    }

    public void playHealSound()
    {
        _soundSource.PlayOneShot(_healSound);
    }

}
