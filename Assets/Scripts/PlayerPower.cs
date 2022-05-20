using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] Transform parent;

    public void Fire()
    {
        Instantiate(objectToBeSpawned, transform.position, Quaternion.identity, parent);
    }
}
