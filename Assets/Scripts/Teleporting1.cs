using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting1 : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject thePlayer;

    private void OnTriggerEnter(Collider other)
    {
        SoundManager.PlaySound("Teleport");
        thePlayer.transform.position = teleportTarget.transform.position;
    }

}
