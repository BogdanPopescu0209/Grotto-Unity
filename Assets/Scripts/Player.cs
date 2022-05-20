using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Text scoreText;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpPower = 8f;
    [SerializeField] private PlayerPower playerPower;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Camera getCamera;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;
    private int countCoins = 0;
    private int countArtefacts = 0;
    private int playerLife = 100;
    private bool allowPower = false;
    private int count = 0;
    private bool allowFire = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        scoreText.text = "Life: " + playerLife.ToString() + "  " + "Coins: " + countCoins.ToString() + "  " + "Artefacts: " + countArtefacts.ToString();
        scoreText.color = Color.red;

        if(playerLife < 0)
        {
            gameOver.Setup();
            getCamera.depth = 2;
        }

        if (rigidBodyComponent.position.y < -10)
        {
            gameOver.Setup();
            getCamera.depth = 2;
        }

        if (!allowFire){
            count++;
        }

        if(count > 1000)
        {
            allowFire = true;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (allowPower)
            {
                if (allowFire)
                {
                    SoundManager.PlaySound("Fire");
                    playerPower.Fire();
                    allowFire = false;
                    count = 0;
                }
            }
        }
    }

    // FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput * speed, rigidBodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            SoundManager.PlaySound("Jump");
            rigidBodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            rigidBodyComponent.transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.CompareTag("Health"))
        {
            SoundManager.PlaySound("Health");
            int newLife = 100;
            playerLife = newLife;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Gate") && countArtefacts == 5)
        {
            SoundManager.PlaySound("Gate");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spider") && collision.transform.position.y >= rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Hit");
            int newLife = playerLife - 10;
            playerLife = newLife;
        }

        if(collision.gameObject.CompareTag("Spider") && (collision.transform.position.y + 0.25)  < rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Destroy");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Goblin") && collision.transform.position.y >= rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Hit");
            int newLife = playerLife - 10;
            playerLife = newLife;
        }

        if (collision.gameObject.CompareTag("Goblin") && (collision.transform.position.y + 0.25) < rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Destroy");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bat") && collision.transform.position.y >= rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Hit");
            int newLife = playerLife - 10;
            playerLife = newLife;
        }

        if (collision.gameObject.CompareTag("Bat") && (collision.transform.position.y + 0.25) < rigidBodyComponent.position.y)
        {
            SoundManager.PlaySound("Destroy");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Power"))
        {
            SoundManager.PlaySound("Power");
            Destroy(collision.gameObject);
            allowPower = true;
        }

            if (collision.gameObject.CompareTag("Bomb"))
        {
            SoundManager.PlaySound("Hit");
            int newLife = playerLife - 15;
            playerLife = newLife;
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            SoundManager.PlaySound("Hit");
            int newLife = playerLife - 25;
            playerLife = newLife;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rigidBodyComponent.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            SoundManager.PlaySound("Coins");
            Destroy(other.gameObject);
            countCoins++;
        }

        if (other.gameObject.layer == 9)
        {
            SoundManager.PlaySound("Artefact");
            Destroy(other.gameObject);
            countArtefacts++;
        }
    }
}