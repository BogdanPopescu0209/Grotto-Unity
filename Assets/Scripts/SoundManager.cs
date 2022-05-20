using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, fireSound, jumpSound, enemyDeathSound, coinsSound, teleportSound, artefactSound, explodeSound, gateSound, healthSound, powerSound,
        gameOverSound, wonSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        coinsSound = Resources.Load<AudioClip>("Coins");
        teleportSound = Resources.Load<AudioClip>("Teleport");
        artefactSound = Resources.Load<AudioClip>("Artefact");
        playerHitSound = Resources.Load<AudioClip>("Hit");
        enemyDeathSound = Resources.Load<AudioClip>("Destroy");
        explodeSound = Resources.Load<AudioClip>("Explode");
        gateSound = Resources.Load<AudioClip>("Gate");
        healthSound = Resources.Load<AudioClip>("Health");
        powerSound = Resources.Load<AudioClip>("Power");
        fireSound = Resources.Load<AudioClip>("Fire");
        gameOverSound = Resources.Load<AudioClip>("GameOver");
        wonSound = Resources.Load<AudioClip>("Won");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSource.PlayOneShot(jumpSound);
                break;
            case "Coins":
                audioSource.PlayOneShot(coinsSound);
                break;
            case "Teleport":
                audioSource.PlayOneShot(teleportSound);
                break;
            case "Artefact":
                audioSource.PlayOneShot(artefactSound);
                break;
            case "Hit":
                audioSource.PlayOneShot(playerHitSound);
                break;
            case "Destroy":
                audioSource.PlayOneShot(enemyDeathSound);
                break;
            case "Explode":
                audioSource.PlayOneShot(explodeSound);
                break;
            case "Gate":
                audioSource.PlayOneShot(gateSound);
                break;
            case "Health":
                audioSource.PlayOneShot(healthSound);
                break;
            case "Power":
                audioSource.PlayOneShot(powerSound);
                break;
            case "Fire":
                audioSource.PlayOneShot(fireSound);
                break;
            case "GameOver":
                audioSource.PlayOneShot(gameOverSound);
                break;
            case "Won":
                audioSource.PlayOneShot(wonSound);
                break;
        }
    }
}
