using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P2Movement : MonoBehaviour
{
    public GameObject soundManager;
    private SoundManager _soundScript;
    public GameObject gameManger;
    private GameManager _gameManager;

    public float speed = 5f;

    Rigidbody2D playerBody;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    public void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _soundScript = soundManager.GetComponent<SoundManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        UserInput();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == 0)
        {
            Destroy(playerBody.gameObject);
            FindObjectOfType<GameManager>().EndGame();
            _soundScript.playLoseSound();
        }

    }

    public void AddHealth(int damage)
    {
        currentHealth += damage;
        healthBar.SetHealth(currentHealth);
    }
    public void UserInput()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.L))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.K))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.I))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 360);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 180);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * -90);
        }

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        //conditions upon player collision

        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage(5);
            _soundScript.playGruntSound();
        }

        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(10);
            _soundScript.playGruntSound();
        }

        else if (other.gameObject.tag == "Win")
        {
            FindObjectOfType<GameManager>().EndGame();
            _soundScript.playWinSound();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            _soundScript.playKeySound();
        }

        if (other.gameObject.CompareTag("Fake"))
        {
            Destroy(other.gameObject);
            _soundScript.playKeyPickUpSound();
        }

        if (other.gameObject.CompareTag("Health"))
        {
            Destroy(other.gameObject);
            AddHealth(25);
            _soundScript.playHealSound();
        }
    }
}
